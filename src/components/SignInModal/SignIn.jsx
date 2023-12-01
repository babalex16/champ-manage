import React, { useState } from 'react'
import { useSelector, useDispatch } from 'react-redux';
import { jwtDecode } from "jwt-decode";
import { Form, Modal, Button } from 'react-bootstrap';
import Cookies from 'js-cookie';
import { setUserField } from "../../redux/signedUserReducer";

function SignInModal() {

  const [loginDetails, setLoginDetails] = useState(
    {
      email: "",
      password: ""
    }
  );

  const dispatch = useDispatch();
  
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setLoginDetails((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Use async/await to ensure the login is completed before calling getUserById
    (async () => {
      await getUserById();
    })();
  };

  const login = async () => {
    try {
      const response = await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/account/login`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(loginDetails),
        }
      );

      if (response.status === 200) {
        const data = await response.json();
        Cookies.set("jwtToken", data.token, { domain: "localhost", path: "/" });
        // Returning the token for further processing if needed
        return data.token;
      } else {
        throw new Error("Network response was not ok.");
      }
    } catch (error) {
      console.error(error);
      // Re-throw the error to propagate it to the next catch block
      throw error;
    }
  };

  const getUserById = async () => {
    try {
      const token = await login();
      const decodedToken = jwtDecode(token);

      const response = await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/users/${decodedToken.user_id}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (response.status === 200) {
        const data = await response.json();
        dispatchUserData(data);
      } else {
        throw new Error("Network response was not ok.");
      }
    } catch (error) {
      console.error(error);
    }
  };

  const dispatchUserData = (userData) => {
    Object.entries(userData).forEach(([key, value]) => {
      dispatch(setUserField(key, value));
    });
  };

  return (
    <>
      <Modal.Header >
        <Modal.Title className="w-100 text-center text-white">Sign In</Modal.Title>
      </Modal.Header>
      <Modal.Body className='d-flex align-items-center justify-content-center flex-column'>
        <Form className='align-items-center my-3' onSubmit={handleSubmit}>
          <Form.Control type="email" id="email" name="email" placeholder="Email" className='form-entry mb-3' value={loginDetails.email}
            onChange={handleInputChange} />
          <Form.Control type="password" id="password" name="password" placeholder="Password" className='form-entry mb-3' value={loginDetails.password}
            onChange={handleInputChange} />
          <Button variant="primary" type="submit" className='form-entry mt-3'>
            Sign In
          </Button>
        </Form>
        <div className='text-center'>
          <a href="#" className="text-decoration-none text-underline">Forgot your password?</a>
        </div>
        <div className='text-center mt-3 mb-1'>
          <a href="/register" className="text-decoration-none text-underline">Create an account</a>
        </div>
      </Modal.Body>
    </>
  )
}

export default SignInModal;