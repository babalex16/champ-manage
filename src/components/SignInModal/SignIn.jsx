import React from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import authService from "../../services/authService/authService";
import { Form, Modal, Button } from "react-bootstrap";
import { useForm } from "react-hook-form";

import Cookies from "js-cookie";
import { loginSuccess } from "../../redux/auth/authActions";

const SignInModal = ({ toggleModal }) => {
  const { register, handleSubmit, formState } = useForm();

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const loginUser = async (loginDetails) => {
    const token = await authService.getUserToken(loginDetails);
    const user = await authService.getUserById(token);
    Cookies.set("user", JSON.stringify(user), {
      domain: "localhost",
      path: "/",
    });
    dispatch(loginSuccess(user));
    navigate("/");
    toggleModal();
  };
  
  return (
    <>
      <Modal.Header>
        <Modal.Title className="w-100 text-center text-white">
          Sign In
        </Modal.Title>
      </Modal.Header>
      <Modal.Body className="d-flex align-items-center justify-content-center flex-column">
        <Form
          className="align-items-center my-3"
          onSubmit={handleSubmit(loginUser)}
        >
          <Form.Control
            type="email"
            id="email"
            name="email"
            placeholder="Email"
            className="form-entry mb-3"
            {...register("email", {
              required: "Email is required",
              pattern: {
                value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i,
                message: "Invalid email address",
              },
            })}
          />
          {!formState.isValid && <p>Invalid email address</p>}
          <Form.Control
            type="password"
            id="password"
            name="password"
            placeholder="Password"
            className="form-entry mb-3"
            {...register("password", { required: true })}
          />
          <Button
            variant="primary"
            type="submit"
            className="form-entry mt-3"
            disabled={!formState.isValid}
          >
            Sign In
          </Button>
        </Form>
        <div className="text-center">
          <a href="/" className="text-decoration-none text-underline">
            Forgot your password?
          </a>
        </div>
        <div className="text-center mt-3 mb-1">
          <a href="/register" className="text-decoration-none text-underline">
            Create an account
          </a>
        </div>
      </Modal.Body>
    </>
  );
};

export default SignInModal;
