import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import './CustomNavbar.css';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import facebook_icon from '../../assets/icons/icons8-facebook-50.svg'
import whatsapp_icon from '../../assets/icons/icons8-whatsapp-50.svg'
import youtube_icon from '../../assets/icons/icons8-youtube-50.svg'
import mjjf_logo_short from '../../assets/icons/mjjf-logo-long-white.png'

function CustomNavbar() {
  const location = useLocation();
  const isFrontPage = location.pathname === '/';
  const [scrolled, setScrolled] = useState(false);
  const [showModal, setShowModal] = useState(false);

  useEffect(() => {
    const handleScroll = () => {
      if (window.scrollY >= 500) {
        setScrolled(true);
      } else {
        setScrolled(false);
      }
    };

    window.addEventListener('scroll', handleScroll);

    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  const handleShowModal = () => {
    setShowModal(true);
  }

  const handleCloseModal = () => {
    setShowModal(false);
  }
  
  return (
    <Navbar
      fixed="top"
      expand="md"
      data-bs-theme="dark"
      className={`${
        isFrontPage ? 'navbar-transparent' : 'navbar-color'
      } ${scrolled ? 'navbar-scrolled' : ''}`}
    >
      <Container>
        <Navbar.Brand href="/">
            <img
              src={mjjf_logo_short}
              width="136"
              height="50"
              className="d-inline-block align-top"
              alt="MJJF Logo"
            />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ms-auto">
            <Nav.Link href="/events" className='nav-style'>Events</Nav.Link>
            <Nav.Link href="/news" className='nav-style'>News</Nav.Link>
            <Nav.Link href="/rules" className='nav-style'>Rules</Nav.Link>
            <Nav.Link href="/contacts" className='nav-style'>Contacts</Nav.Link>
            <Nav.Link onClick={handleShowModal} className='nav-style'>Sign in</Nav.Link>
            <Nav.Link href="https://www.facebook.com/JiuJitsuMoldova" target="_blank"><img src={facebook_icon} alt="Facebook" className="icons-size"/></Nav.Link>
            <Nav.Link href="#" target="_blank"><img src={whatsapp_icon} alt="Whatsapp" className="icons-size"/></Nav.Link>
            <Nav.Link href="https://www.youtube.com/@federatianationaladejiu-ji6267" target="_blank"><img src={youtube_icon} alt="Youtube" className="icons-size"/></Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
      <Modal 
        centered 
        show={showModal} 
        onHide={handleCloseModal} 
      >
      <Modal.Header >
        <Modal.Title className="w-100 text-center text-white">Sign In</Modal.Title>
      </Modal.Header>
      <Modal.Body className='d-flex align-items-center justify-content-center flex-column'>  
        <Form className='align-items-center my-3'>
          <Form.Control type="email" id="email" placeholder="Email" className='form-entry mb-3'/>
          <Form.Control type="password" id="password" placeholder="Password" className='form-entry mb-3'/>
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
      </Modal>
    </Navbar>
  )
}

export default CustomNavbar