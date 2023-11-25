import React, {useState} from 'react'
import { useSelector, useDispatch } from 'react-redux';
import Cookies from 'js-cookie';
import { Form, Modal, Button } from 'react-bootstrap';

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
        setLoginDetails(prevState => ({
          ...prevState,
          [name]: value
        }));
      };
    
      const handleSubmit = (e) => {
        e.preventDefault();
        // Use the updated loginDetails state for form submission or other actions
        login();
        console.log(loginDetails);
      };

      const login = ( ) => {
        fetch( `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/account/login`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginDetails)
          })
          .then((response) => {
            console.log('Response status is ' +response.status)
            if (response.status === 200) {
              return response.json();
            } else {
              throw new Error('Network response was not ok.');
            }
        })
            .then((data) => {
              // Handle the data from the API here
                dispatch( 
                {
                    type: 'SET_JWT',
                    payload: data.token
                })
              console.log(data);
               // Store JWT token in an HTTP-only cookie
                Cookies.set('jwtToken', data.token,  {domain: 'localhost', path:'/' });
                console.log("From Sign In " + Cookies.get('jwtToken'));
            })
            .catch((error) => {
              // Handle errors here
              console.error(error);
            });
    }

  return (
    <>
        <Modal.Header >
            <Modal.Title className="w-100 text-center text-white">Sign In</Modal.Title>
        </Modal.Header>
        <Modal.Body className='d-flex align-items-center justify-content-center flex-column'>  
            <Form className='align-items-center my-3' onSubmit={handleSubmit}>
                <Form.Control type="email" id="email" name="email" placeholder="Email" className='form-entry mb-3' value={loginDetails.email}
                    onChange={handleInputChange}/>
                <Form.Control type="password" id="password" name="password" placeholder="Password" className='form-entry mb-3' value={loginDetails.password}
                    onChange={handleInputChange}/>
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

export default SignInModal ;