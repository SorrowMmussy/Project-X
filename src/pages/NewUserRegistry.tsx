import axios from 'axios';
import React, { useState } from 'react';
import { Alert, Button, Form } from 'react-bootstrap';
import { Cookies } from 'react-cookie';
import { useHistory, useParams } from 'react-router';
import { isExpired, decodeToken } from 'react-jwt';

const NewUserRegistry = () => {
    const [userEmail, setUserEmail] = useState('');
    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);

    function sendEmail(userEmail: string) {
        return axios
            .post(
                'http://localhost:54592/Authentication/EmailRegistration',
                { Email: userEmail },
                {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                }
            )
            .then((response) => {});
    }

    const handleEmailSubmit = () => {
        setAlertVisible(false);

        sendEmail(userEmail);
    };

    return (
        <>
            <Form
                onSubmit={(e) => {
                    e.preventDefault();
                    handleEmailSubmit();
                }}
            >
                <Form.Group controlId="email">
                    <Form.Label>Email address</Form.Label>
                    <Form.Control
                        placeholder={'Enter email address to send invite for the platform'}
                        type="email"
                        value={userEmail}
                        onChange={(e) => setUserEmail(e.target.value)}
                    />
                </Form.Group>

                <>
                    <Button as="input" type="submit" value="Send invite" />
                </>
            </Form>

            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
        </>
    );
};

export default NewUserRegistry;
