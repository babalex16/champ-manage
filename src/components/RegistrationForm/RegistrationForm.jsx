import React from "react";
import { Form, Button, FormControl, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";

import authService from "../../services/authService/authService";

import "./RegistrationForm.css";

const RegistrationForm = () => {
  const { register, handleSubmit, formState } = useForm();

  const navigate = useNavigate();

  const registerUserDetails = async (registerDetails) => {
    await authService.registerUser(registerDetails);

    navigate("/");
  };

  return (
    <div className="page-background">
      <Row className="justify-content-center">
        <Col md={6} className="form-background">
          <Form onSubmit={handleSubmit(registerUserDetails)}>
            <Row className="mb-3">
              <Col>
                <Form.Label>First Name</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter first name"
                  style={{ borderRadius: "15px" }}
                  name="firstName"
                />
              </Col>
              <Col>
                <Form.Label>Last Name</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter last name"
                  style={{ borderRadius: "15px" }}
                  name="lastName"
                />
              </Col>
            </Row>
            <Form.Label>Email address</Form.Label>
            <FormControl
              type="email"
              placeholder="Enter email"
              style={{ borderRadius: "15px" }}
              name="email"
              {...register("email", {
                required: "Email is required",
                pattern: {
                  value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i,
                  message: "Invalid email address",
                },
              })}
            />
            <Form.Label>Password</Form.Label>
            <FormControl
              type="password"
              placeholder="Enter password"
              style={{ borderRadius: "15px" }}
              name="password"
              {...register("password", { required: true })}
            />
            <Form.Label>Confirm Password</Form.Label>
            <FormControl
              type="password"
              placeholder="Confirm password"
              style={{ borderRadius: "15px" }}
              name="confirmPassword"
              {...register("confirmPassword", { required: true })}
            />
            <Button
              variant="primary"
              type="submit"
              disabled={!formState.isValid}
              style={{ borderRadius: "15px", width: "100%", marginTop: "20px" }}
            >
              Create Account
            </Button>
          </Form>
        </Col>
      </Row>
    </div>
  );
};

export default RegistrationForm;
