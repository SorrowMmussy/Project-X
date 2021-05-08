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
    const [detonatorTypeId, setDetonatorTypeId] = useState('');
    const [width, setWidth] = useState('');
    const [length, setLength] = useState('');
    const [height, setHeight] = useState('');
    const [material, setMaterial] = useState('');
    const [tier, setTier] = useState('');
    const [assembly, setAssembly] = useState('');
    const [note, setNote] = useState('');

    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);

    function addExplosiveData(username: string, password: string) {
        //stuff
    }

    const handleSubmit = () => {
        setAlertVisible(false);

        addExplosiveData(userName, password);
    };

    return (
        <>
            <Form
                onSubmit={(e) => {
                    e.preventDefault();
                    handleSubmit();
                }}
            >
                <Form.Control value={userName} onChange={(e) => setUserName(e.target.value)} />
                <Form.Control value={password} onChange={(e) => setPassword(e.target.value)} />
                <button type="submit">login</button>
            </Form>

            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
        </>
    );
};
export default ExplosiveRegisterPage;
