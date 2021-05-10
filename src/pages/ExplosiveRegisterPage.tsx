import axios from 'axios';
import React, { useState } from 'react';
import { Alert, Form } from 'react-bootstrap';
import { Cookies } from 'react-cookie';
import { useHistory, useParams } from 'react-router';
import { isExpired, decodeToken } from 'react-jwt';

const ExplosiveRegisterPage = () => {
    const [name, setName] = useState('');
    const [category, setCategory] = useState('');
    const [manufacturersCountry, setManufacturersCountry] = useState('');
    const [caliber, setCaliber] = useState('');
    const [explosivePurpose, setExplosivePurpose] = useState('');
    const [detonatorType, setDetonatorType] = useState('');
    const [width, setWidth] = useState('');
    const [length, setLength] = useState('');
    const [height, setHeight] = useState('');
    const [material, setMaterial] = useState('');
    const [tier, setTier] = useState('');
    const [assembly, setAssembly] = useState('');
    const [note, setNote] = useState('');

    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);

    function addExplosiveData(
        name: string,
        category: string,
        manufacturersCountry: string,
        caliber: string,
        explosivePurpose: string,
        detonatorType: string,
        width: string,
        length: string,
        height: string,
        material: string,
        tier: string,
        assembly: string,
        note: string
    ) {
        return axios.post(
            'http://localhost:54592/ExplosivesData/Add',
            {
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
            caliber,
            explosivePurpose,
            detonatorType,
            width,
            length,
            height,
            material,
            tier,
            assembly,
            note
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
                <Form.Group controlId="exampleForm.ControlInput1">
                    <Form.Label>Name</Form.Label>
                    <Form.Control
                        value={name}
                        placeholder={'The name of explosive'}
                        onChange={(e) => setName(e.target.value)}
                    />
                </Form.Group>

                <Form.Control value={category} onChange={(e) => setCategory(e.target.value)} />
                <Form.Control value={manufacturersCountry} onChange={(e) => setManufacturersCountry(e.target.value)} />
                <Form.Control value={caliber} onChange={(e) => setCaliber(e.target.value)} />
                <Form.Control value={explosivePurpose} onChange={(e) => setExplosivePurpose(e.target.value)} />
                <Form.Control value={detonatorType} onChange={(e) => setDetonatorType(e.target.value)} />
                <Form.Control value={width} onChange={(e) => setWidth(e.target.value)} />
                <Form.Control value={length} onChange={(e) => setLength(e.target.value)} />
                <Form.Control value={height} onChange={(e) => setHeight(e.target.value)} />
                <Form.Control value={material} onChange={(e) => setMaterial(e.target.value)} />
                <Form.Control value={tier} onChange={(e) => setTier(e.target.value)} />
                <Form.Control value={assembly} onChange={(e) => setAssembly(e.target.value)} />
                <Form.Control value={note} onChange={(e) => setNote(e.target.value)} />

                <button type="submit">Add explosives data</button>
            </Form>

            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
        </>
    );
};
export default ExplosiveRegisterPage;
