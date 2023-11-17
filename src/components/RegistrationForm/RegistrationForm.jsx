import React, { useState } from 'react';
import { Form, Button, FormControl, Row, Col } from 'react-bootstrap';
import './RegistrationForm.css'

function RegistrationForm() {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
        password: '',
    });

    const handleChange = (event) => {
        setFormData((prevState) => ({
            ...prevState,
            [event.target.name]: event.target.value,
        }));
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        // Client-side password validation
        if (formData.password !== formData.confirmPassword) {
            alert("Passwords do not match");
            return;
        }

        try {
            //Perforing API request
            const response = await fetch('https://localhost:7200/api/account/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });
            const data = await response.json();
            console.log(data);

        } catch (error) {
            // Handling API request errors
            console.error("API request error:", error);
        }
    };

    return (
        <div className='page-background' >
            <Row className="justify-content-center">
                <Col md={6} className='form-background'>
                    <Form onSubmit={handleSubmit}>
                        <Row className="mb-3">
                            <Form.Group as={Col} xs={12} md={6} controlId="formFirstName">
                                <Form.Label>First Name</Form.Label>
                                <Form.Control type="text" 
                                              placeholder="Enter first name" 
                                              style={{ borderRadius: '15px' }} 
                                              required name="firstName" 
                                              value={formData.firstName} 
                                              onChange={handleChange} />
                            </Form.Group>
                            <Form.Group as={Col} xs={12} md={6} controlId="formLastName">
                                <Form.Label>Last Name</Form.Label>
                                <Form.Control   type="text" 
                                                placeholder="Enter last name" 
                                                style={{ borderRadius: '15px' }} 
                                                required name="lastName" 
                                                value={formData.lastName} 
                                                onChange={handleChange} />
                            </Form.Group>
                        </Row>
                        <Form.Group className="mb-3" controlId="formEmail">
                            <Form.Label>Email address</Form.Label>
                            <FormControl    type="email" 
                                            placeholder="Enter email" 
                                            style={{ borderRadius: '15px' }} 
                                            required name="email" 
                                            value={formData.email} 
                                            onChange={handleChange} />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formPassword">
                            <Form.Label>Password</Form.Label>
                            <FormControl    type="password" 
                                            placeholder="Enter password" 
                                            style={{ borderRadius: '15px' }} 
                                            required name="password" 
                                            value={formData.password} 
                                            onChange={handleChange} />
                        </Form.Group>
                        <Form.Group className="mb-4" controlId="formConfirmPassword">
                            <Form.Label>Confirm Password</Form.Label>
                            <FormControl type="password" 
                                         placeholder="Confirm password"
                                         style={{ borderRadius: '15px' }} 
                                         required name="confirmPassword" 
                                         value={formData.confirmPassword} 
                                         onChange={handleChange} />
                        </Form.Group>
                        <Button variant="primary" type="submit" style={{ borderRadius: '15px', width: '100%' }}>
                            Create Account
                        </Button>
                    </Form>
                </Col>
            </Row>
        </div>
    );
}

export default RegistrationForm