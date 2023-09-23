import React from 'react'
import { Form, Button, FormControl, Row, Col } from 'react-bootstrap';
import './RegistrationForm.css'

function RegistrationForm() {   
    return (
        <div className='page-background' >
            <Row className="justify-content-center">
                <Col md={6} className='form-background'>
                    <Form>
                        <Row className="mb-3">
                        <Form.Group as={Col} xs={12} md={6} controlId="formFirstName">
                            <Form.Label>First Name</Form.Label>
                            <Form.Control type="text" placeholder="Enter first name" style={{ borderRadius: '15px' }} required />
                        </Form.Group>
    
                        <Form.Group as={Col} xs={12} md={6} controlId="formLastName">
                            <Form.Label>Last Name</Form.Label>
                            <Form.Control type="text" placeholder="Enter last name" style={{ borderRadius: '15px' }} required />
                        </Form.Group>
                        </Row>
    
                        <Form.Group className="mb-3" controlId="formEmail">
                            <Form.Label>Email address</Form.Label>
                            <FormControl type="email" placeholder="Enter email" style={{ borderRadius: '15px' }} required />
                        </Form.Group>
    
                        <Form.Group className="mb-3" controlId="formPassword">
                            <Form.Label>Password</Form.Label>
                            <FormControl type="password" placeholder="Enter password" style={{ borderRadius: '15px' }} required />
                        </Form.Group>
    
                        <Form.Group className="mb-4" controlId="formConfirmPassword">
                        <Form.Label>Confirm Password</Form.Label>
                            <FormControl type="password" placeholder="Confirm password" style={{ borderRadius: '15px' }} required />
                        </Form.Group>
    
                        <Button variant="primary" type="submit" style={{ borderRadius: '15px', width: '100%' }}>
                             Create Account
                        </Button>
                    </Form>
                </Col>
            </Row>
        </div>
    )
}

export default RegistrationForm