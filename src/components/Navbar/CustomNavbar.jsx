import React, { useEffect, useState } from "react";
import Cookies from "js-cookie";
import { useLocation } from "react-router-dom";
import { useDispatch } from "react-redux";

import facebook_icon from "../../assets/icons/icons8-facebook-50.svg";
import whatsapp_icon from "../../assets/icons/icons8-whatsapp-50.svg";
import youtube_icon from "../../assets/icons/icons8-youtube-50.svg";
import mjjf_logo_short from "../../assets/icons/mjjf-logo-long-white.png";

import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Modal from "react-bootstrap/Modal";
import authService from "../../services/authService/authService";
import SignInModal from "../SignInModal/SignIn";
import { logout } from "../../redux/auth/authActions";

import "./CustomNavbar.css";

const CustomNavbar = () => {
  const location = useLocation();
  const isFrontPage = location.pathname === "/";
  const [scrolled, setScrolled] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const dispatch = useDispatch();

  useEffect(() => {
    handleScroll();
  }, []);


  const handleScroll = () => {
    const scroll = () => {
      if (window.scrollY >= 500) {
        setScrolled(true);
      } else {
        setScrolled(false);
      }
    };

    window.addEventListener("scroll", scroll);

    return () => {
      window.removeEventListener("scroll", scroll);
    };
  }
  const toggleModal = () => {
    setShowModal((prevState) => !prevState);
  };

  const signOut = () => {
    authService.signOut();
    dispatch(logout());
  };

  return (
    <Navbar
      fixed="top"
      expand="md"
      data-bs-theme="dark"
      className={`${isFrontPage ? "navbar-transparent" : "navbar-color"} ${
        scrolled ? "navbar-scrolled" : ""
      }`}
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
            <Nav.Link href="/championships" className="nav-style">
              Events
            </Nav.Link>
            <Nav.Link href="/news" className="nav-style">
              News
            </Nav.Link>
            <Nav.Link href="/rules" className="nav-style">
              Rules
            </Nav.Link>
            <Nav.Link href="/contacts" className="nav-style">
              Contacts
            </Nav.Link>
            {!Cookies.get("jwtToken") && (
              <Nav.Link className="nav-style" onClick={toggleModal}>
                Sign in
              </Nav.Link>
            )}
            {Cookies.get("jwtToken") && (
              <>
                <Nav.Link className="nav-style" href="/account">
                  Profile
                </Nav.Link>
                <Nav.Link className="nav-style" href="/" onClick={signOut}>
                  Sign Out
                </Nav.Link>
              </>
            )}

            <Nav.Link
              href="https://www.facebook.com/JiuJitsuMoldova"
              target="_blank"
            >
              <img src={facebook_icon} alt="Facebook" className="icons-size" />
            </Nav.Link>
            <Nav.Link href="#" target="_blank">
              <img src={whatsapp_icon} alt="Whatsapp" className="icons-size" />
            </Nav.Link>
            <Nav.Link
              href="https://www.youtube.com/@federatianationaladejiu-ji6267"
              target="_blank"
            >
              <img src={youtube_icon} alt="Youtube" className="icons-size" />
            </Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
      <Modal centered show={showModal} onHide={toggleModal}>
        <SignInModal toggleModal={toggleModal} />
      </Modal>
    </Navbar>
  );
};

export default CustomNavbar;
