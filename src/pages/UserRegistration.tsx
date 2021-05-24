import axios from 'axios';
import React, { useState } from 'react';
import { Alert, Form } from 'react-bootstrap';
import { useParams } from 'react-router';

const UserRegistration = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [repeatPassword, setRepeatPassword] = useState('');

    const [alertText, setAlertText] = useState('');

    const [isAlertVisible, setAlertVisible] = useState(false);

    const handleSubmit = () => {
        setAlertVisible(false);
        if (password !== repeatPassword) {
            setAlertText('nesutampa');
            setAlertVisible(true);
            return;
        }

        axios
            .post('http://localhost:54592/Authentification/Add', { username: userName, password: password })
            .then((response) => {
                setAlertText('Uzregistruotas');
                setAlertVisible(true);
            })
            .catch((response) => {
                console.log(response);
                setAlertText('error');
                setAlertVisible(true);
            });
    };

    return (
        <>
            <Form
                onSubmit={(e) => {
                    e.preventDefault();
                    handleSubmit();
                }}
            >
                <Form.Group controlId="manufacturersCountry">
                    <Form.Label>Username</Form.Label>
                    <Form.Control value={userName} onChange={(e) => setUserName(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="manufacturersCountry">
                    <Form.Label>Password</Form.Label>
                    <Form.Control value={password} onChange={(e) => setPassword(e.target.value)} />
                </Form.Group>

                <Form.Group controlId="manufacturersCountry">
                    <Form.Label>Repeat password</Form.Label>
                    <Form.Control value={repeatPassword} onChange={(e) => setRepeatPassword(e.target.value)} />
                </Form.Group>
                <button type="submit">Comfirm</button>
            </Form>

            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
        </>
    );
};

export default UserRegistration;
