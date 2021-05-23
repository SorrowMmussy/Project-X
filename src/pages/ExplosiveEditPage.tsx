import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Alert, Button, Form } from 'react-bootstrap';
import { Cookies } from 'react-cookie';
import { useHistory, useParams } from 'react-router';
import { isExpired, decodeToken } from 'react-jwt';
import { Explosive } from './ExplosiveSearchPage';
import { idText } from 'typescript';

const ExplosiveEditPage = () => {
    const [name, setName] = useState('');
    const [category, setCategory] = useState('');
    const [manufacturersCountry, setManufacturersCountry] = useState('');
    const [caliber, setCaliber] = useState('');
    const [explosivePurpose, setExplosivePurpose] = useState('');
    const [detonatorType, setDetonatorType] = useState('');
    const [width, setWidth] = useState<number>();
    const [length, setLength] = useState<number>();
    const [height, setHeight] = useState<number>();
    const [material, setMaterial] = useState('');
    const [tier, setTier] = useState('');
    const [assembly, setAssembly] = useState('');
    const [note, setNote] = useState('');

    const { id } = useParams<{ id: string }>();

    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);

    useEffect(() => {
        axios.get<Explosive>('http://localhost:54592/ExplosivesData/GetById?id=' + id).then((response) => {
            const data = response.data;
            setName(data.name);
            setCategory(data.category);
        });
    }, [id]);

    function addExplosiveData(
        name: string,
        category: string,
        manufacturersCountry: string,
        explosivePurpose: string,
        detonatorType: string,
        material: string,
        assembly: string,
        note: string,
        tier: string,
        caliber: string,
        width?: number,
        length?: number,
        height?: number
    ) {
        return axios.post(
            'http://localhost:54592/ExplosivesData/Edit',
            {
                Id: Number(id),
                Name: name,
                Category: category,
                ManufacturersCountry: manufacturersCountry,
                Caliber: caliber,
                ExplosivePurpose: explosivePurpose,
                DetonatorType: detonatorType,
                Width: width,
                Length: length,
                Height: height,
                Material: material,
                Tier: tier,
                Assembly: assembly,
                Note: note,
            },
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
            }
        );
    }

    const handleSubmit = () => {
        setAlertVisible(false);

        addExplosiveData(
            name,
            category,
            manufacturersCountry,
            explosivePurpose,
            detonatorType,
            material,
            assembly,
            note,
            tier,
            caliber,
            width,
            length,
            height
        );
    };

    return (
        <>
            <Form
                onSubmit={(e) => {
                    e.preventDefault();
                    handleSubmit();
                }}
            >
                <Form.Group controlId="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control
                        value={name}
                        placeholder={'The name of explosive'}
                        onChange={(e) => setName(e.target.value)}
                    />
                </Form.Group>

                <Form.Group controlId="category">
                    <Form.Label>Category</Form.Label>
                    <Form.Control value={category} onChange={(e) => setCategory(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="manufacturersCountry">
                    <Form.Label>Manufacturers country</Form.Label>
                    <Form.Control
                        value={manufacturersCountry}
                        onChange={(e) => setManufacturersCountry(e.target.value)}
                    />
                </Form.Group>

                <Form.Group controlId="caliber">
                    <Form.Label>Caliber</Form.Label>
                    <Form.Control value={caliber} onChange={(e) => setCaliber(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="explosivePurpose">
                    <Form.Label>Explosives purpose</Form.Label>
                    <Form.Control value={explosivePurpose} onChange={(e) => setExplosivePurpose(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="detonatorType">
                    <Form.Label>Detonator type</Form.Label>
                    <Form.Control value={detonatorType} onChange={(e) => setDetonatorType(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="width">
                    <Form.Label>Width</Form.Label>
                    <Form.Control type="number" value={width} onChange={(e) => setWidth(Number(e.target.value))} />
                </Form.Group>

                <Form.Group controlId="length">
                    <Form.Label>Length</Form.Label>
                    <Form.Control type="number" value={length} onChange={(e) => setLength(Number(e.target.value))} />
                </Form.Group>

                <Form.Group controlId="height">
                    <Form.Label>Height</Form.Label>
                    <Form.Control type="number" value={height} onChange={(e) => setHeight(Number(e.target.value))} />
                </Form.Group>

                <Form.Group controlId="material">
                    <Form.Label>Material</Form.Label>
                    <Form.Control value={material} onChange={(e) => setMaterial(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="tier">
                    <Form.Label>Tier</Form.Label>
                    <Form.Control value={tier} onChange={(e) => setTier(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="assembly">
                    <Form.Label>Assembly</Form.Label>
                    <Form.Control value={assembly} onChange={(e) => setAssembly(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="note">
                    <Form.Label>Note</Form.Label>
                    <Form.Control value={note} onChange={(e) => setNote(e.target.value)} />
                </Form.Group>
                <>
                    <Button as="input" type="submit" value="Save edit" />
                </>
            </Form>

            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
        </>
    );
};
export default ExplosiveEditPage;
