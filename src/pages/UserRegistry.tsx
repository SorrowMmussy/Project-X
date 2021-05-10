import axios from 'axios';
import React, { useState } from 'react';
import { Alert, Form } from 'react-bootstrap';
import { Cookies } from 'react-cookie';
import { useHistory, useParams } from 'react-router';
import { isExpired, decodeToken } from 'react-jwt';

const UserRegistry = () => {
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
                <Form.Control type="email" value={userEmail} onChange={(e) => setUserEmail(e.target.value)} />
                <button type="submit">Send new user email registration</button>
            </Form>

            <Alert variant="danger" show={isAlertVisible}>
                {alertText}
            </Alert>
        </>
    );
};

export default UserRegistry;
