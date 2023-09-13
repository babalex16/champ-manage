import React, { useEffect, useState } from 'react';
import './CustomNavbar.css';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import facebook_icon from '../../assets/icons/icons8-facebook-50.svg'
import whatsapp_icon from '../../assets/icons/icons8-whatsapp-50.svg'
import youtube_icon from '../../assets/icons/icons8-youtube-50.svg'
import settings_icon from '../../assets/icons/icons8-settings-50.svg'
import log_out_icon from '../../assets/icons/icons8-greater-than-50.svg'
import user_icon from '../../assets/icons/user-icon.svg'
import mjjf_logo_short from '../../assets/icons/mjjf-logo-short.png'

function CustomNavbar() {
  const [scrolled, setScrolled] = useState(false);

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
  
  return (
    <Navbar fixed="top" expand="md" data-bs-theme="dark" className={scrolled ? 'navbar-scrolled' : ''}>
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
            <NavDropdown title="Account" id="basic-nav-dropdown">
              <NavDropdown.Item href="/account">
                <img src={user_icon} alt="User" className="menu-icons-size "/> 
                 My account
              </NavDropdown.Item>
              <NavDropdown.Item href="#Settings">
                <img src={settings_icon} alt="Settings" className="menu-icons-size"/>
                 Settings
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#logOut">
                <img src={log_out_icon} alt="log out" className="menu-icons-size"/>
                Log out
              </NavDropdown.Item>
            </NavDropdown>
            <Nav.Link href="https://www.facebook.com/JiuJitsuMoldova" target="_blank"><img src={facebook_icon} alt="Facebook" className="icons-size"/></Nav.Link>
            <Nav.Link href="#" target="_blank"><img src={whatsapp_icon} alt="Whatsapp" className="icons-size"/></Nav.Link>
            <Nav.Link href="https://www.youtube.com/@federatianationaladejiu-ji6267" target="_blank"><img src={youtube_icon} alt="Youtube" className="icons-size"/></Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  )
}

export default CustomNavbar