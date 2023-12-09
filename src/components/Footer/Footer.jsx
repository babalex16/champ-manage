import React from 'react';
import facebook_icon from '../../assets/icons/icons8-facebook-50.svg'
import whatsapp_icon from '../../assets/icons/icons8-whatsapp-50.svg'
import youtube_icon from '../../assets/icons/icons8-youtube-50.svg'
import logo from '../../assets/icons/mjjf-logo-long-white.png';
import './Footer.css';

const Footer = ({backgroundColor}) => {
  return (
    <div className="footer-container" style={{ backgroundColor }}>
      <img src={logo} alt="Logo" className="logo" />
      <div className="icons-container">
        <a href="https://www.facebook.com/JiuJitsuMoldova" target="_blank" rel="noreferrer noopener">
          <img src={facebook_icon} alt="Facebook" className="icon" />
        </a>
        <a href="/" target="_blank" rel="noreferrer noopener">
          <img src={whatsapp_icon} alt="Whatsapp" className="icon" />
        </a>
        <a href="https://www.youtube.com/@federatianationaladejiu-ji6267" target="_blank" rel="noreferrer noopener">
          <img src={youtube_icon} alt="Youtube" className="icon" />
        </a>
      </div>
    </div>
  );
}

export default Footer;