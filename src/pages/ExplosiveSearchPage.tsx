import axios from 'axios';
import React, { useState } from 'react';
import { Alert, Button, Form } from 'react-bootstrap';
import { useTable } from 'react-table';
import { CSVLink } from 'react-csv';

export interface Explosive {
    [index: string]: any;
    name: string;
    category: string;
    id: number;
}

const ExplosiveSearchPage = () => {
    const [name, setName] = useState('');
    const [data, setData] = useState<Explosive[]>([]);

    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);

    const columns = React.useMemo(
        () => [
            {
                Header: 'Name',
                accessor: 'name', // accessor is the "key" in the data
            },
            {
                Header: 'Category',
                accessor: 'category', // accessor is the "key" in the data
            },
            {
                Header: '',
                accessor: 'id',
                Cell: (row: any) => (
                    <div>
                        <a href={'/explosiveEditPage/' + row.row.original.id}>Edit</a>|
                        <a
                            href="#"
                            onClick={() => {
                                axios.delete('http://localhost:54592/ExplosivesData/Delete?id=' + row.row.original.id);
                                setData(data.filter((d) => d.id !== row.row.original.id));
                            }}
                        >
                            Delete
                        </a>
                    </div>
                ),
            },
        ],
        []
    );

    const tableInstance = useTable({ columns, data });

    function addExplosiveData(name: string) {
        return axios
            .get<Explosive[]>('http://localhost:54592/ExplosivesData/Search?name=' + name)
            .then((response) => setData(response.data));
    }

    const handleSubmit = () => {
        setAlertVisible(false);

        addExplosiveData(name);
    };

    const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } = tableInstance;

    return (
        <>
            <CSVLink data={data}>Export to CSV</CSVLink>
            <Form
                onSubmit={(e) => {
                    e.preventDefault();
                    handleSubmit();
                }}
            >
                <Form.Group controlId="name">
                    <Form.Label>Search explosves by Name</Form.Label>
                    <Form.Control
                        value={name}
                        placeholder={'The name of explosive'}
                        onChange={(e) => setName(e.target.value)}
                    />
                </Form.Group>

                <>
                    <Button as="input" type="submit" value="Search explosives data" />
                </>
            </Form>
            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
            <table {...getTableProps()}>
                <thead>
                    {
                        // Loop over the header rows
                        headerGroups.map((headerGroup) => (
                            // Apply the header row props
                            <tr {...headerGroup.getHeaderGroupProps()}>
                                {
                                    // Loop over the headers in each row
                                    headerGroup.headers.map((column) => (
                                        // Apply the header cell props
                                        <th {...column.getHeaderProps()}>
                                            {
                                                // Render the header
                                                column.render('Header')
                                            }
                                        </th>
                                    ))
                                }
                            </tr>
                        ))
                    }
                </thead>
                {/* Apply the table body props */}
                <tbody {...getTableBodyProps()}>
                    {
                        // Loop over the table rows
                        rows.map((row) => {
                            // Prepare the row for display
                            prepareRow(row);
                            return (
                                // Apply the row props
                                <tr {...row.getRowProps()}>
                                    {
                                        // Loop over the rows cells
                                        row.cells.map((cell) => {
                                            // Apply the cell props
                                            return (
                                                <td {...cell.getCellProps()}>
                                                    {
                                                        // Render the cell contents
                                                        cell.render('Cell')
                                                    }
                                                </td>
                                            );
                                        })
                                    }
                                </tr>
                            );
                        })
                    }
                </tbody>
            </table>
        </>
    );
};
export default ExplosiveSearchPage;
