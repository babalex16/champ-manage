import React from 'react';
import facebook_icon from '../../assets/icons/icons8-facebook-50.svg'
import whatsapp_icon from '../../assets/icons/icons8-whatsapp-50.svg'
import youtube_icon from '../../assets/icons/icons8-youtube-50.svg'
import logo from '../../assets/icons/mjjf-logo-long-white.png';
import './Footer.css';

function Footer() {
  return (
    <div className="footer-container">
      <img src={logo} alt="Logo" className="logo" />
      <div className="icons-container">
        <a href="https://www.facebook.com/JiuJitsuMoldova" target="_blank" >
          <img src={facebook_icon} alt="Facebook" className="icon" />
        </a>
        <a href="#" target="_blank">
          <img src={whatsapp_icon} alt="Whatsapp" className="icon" />
        </a>
        <a href="https://www.youtube.com/@federatianationaladejiu-ji6267" target="_blank">
          <img src={youtube_icon} alt="Youtube" className="icon" />
        </a>
      </div>
    </div>
  );
}

export default Footer;