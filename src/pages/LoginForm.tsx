import axios from 'axios';
import React, { useState } from 'react';
import { Alert, Form } from 'react-bootstrap';
import { useParams } from 'react-router';

const LoginForm = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [alertText, setAlertText] = useState('');
    const [isAlertVisible, setAlertVisible] = useState(false);

    const handleSubmit = () => {
        setAlertVisible(false);

        //uuuummmmm
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
