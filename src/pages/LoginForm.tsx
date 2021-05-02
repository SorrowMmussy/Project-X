import axios from 'axios';
import React, { useState } from 'react';
import { Alert, Form } from 'react-bootstrap';
import { Cookies } from 'react-cookie';
import { useParams } from 'react-router';

const LoginForm = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);
    const jwtCookieName = 'jwt';
    const cookies = new Cookies();

    function login(username: string, password: string) {
        return axios
            .post(
                'http://localhost:54592/Authentification/Authenticate',
                { Username: username, Password: password },
                {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    withCredentials: true,
                }
            )
            .then((response) => {
                cookies.set(jwtCookieName, response.data, { sameSite: 'strict' });
            });
    }

    const handleSubmit = () => {
        setAlertVisible(false);

        login(userName, password);
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

export default LoginForm;
