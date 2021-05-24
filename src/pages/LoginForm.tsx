import axios from 'axios';
import React, { useState } from 'react';

import { Alert, Form } from 'react-bootstrap';
import { Cookies } from 'react-cookie';
import { useHistory, useParams } from 'react-router';
import { isExpired, decodeToken } from 'react-jwt';

import './LoginForm.scss';

const cookies = new Cookies();
const jwtCookieName = 'jwt';

const LoginForm = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);
    const history = useHistory();

    function login(username: string, password: string) {
        return axios
            .post(
                'http://localhost:54592/Authentication/Authenticate',
                { Username: username, Password: password },
                {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                }
            )
            .then((response) => {
                cookies.set(jwtCookieName, response.data, { sameSite: 'strict' });
                history.push('/');
            });
    }

    const handleSubmit = () => {
        setAlertVisible(false);

        login(userName, password);
    };

    return (
        <>
            <Form
                className="LoginForm"
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
                    <Form.Label>Username</Form.Label>
                    <Form.Control value={password} onChange={(e) => setPassword(e.target.value)} />
                </Form.Group>
                <button type="submit">Log in</button>
            </Form>

            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
        </>
    );
};

export function isLoggedIn() {
    const token = cookies.get(jwtCookieName);
    const isTokenExpired = isExpired(token);
    if (isTokenExpired) {
        logout();
    }
    return token !== undefined && !isTokenExpired;
}

function logout() {
    cookies.remove(jwtCookieName);
}

export default LoginForm;
