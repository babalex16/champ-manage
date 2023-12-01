import React, { useEffect, useState } from 'react';
import Cookies from 'js-cookie';
import { useLocation } from 'react-router-dom';
import './CustomNavbar.css';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Modal from 'react-bootstrap/Modal';
import SignInModal from '../SignInModal/SignIn';
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
  
  const tryCookie = () => {
    const jwtToken = Cookies.get('jwtToken');
    console.log("the token is: " + jwtToken);
    fetch(`${process.env.REACT_APP_CHAMP_MANAGE_API}/api/users/10`, {
      method: 'GET',
      headers: {
        Authorization: `Bearer ${jwtToken}`,
      },
    })
    .then((response) => {
      if (response.status === 200) {
        return response.json();
      } else {
        throw new Error('Network response was not ok.');
      }
    })
      .then((data) => {
        // Handle the data from the API here
        console.log(data);
      })
      .catch((error) => {
        // Handle errors here
        console.error(error);
      });
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
        <Navbar.Brand href="" onClick={tryCookie}>
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
        <SignInModal/>
      </Modal>
    </Navbar>
  )
}

export default CustomNavbar