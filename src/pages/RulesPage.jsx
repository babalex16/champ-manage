import React from 'react'
import Button from 'react-bootstrap/Button';
import Image from 'react-bootstrap/Image';
import ruleBook from '../assets/pdfs/EN_IBJJF_RulesBook_MAR2022.pdf'
import ruleImg from '../assets/photos/rule-book.jpg';
import Footer from '../components/Footer/Footer';

function RulesPage() {
  return (
    <div style={{ paddingTop: '80px', backgroundColor: '#5c8374', minHeight: '100vh' }}>
      <h2 className="text-white text-center mt-4">Rules</h2>
      <Image src={ruleImg} fluid className="mx-auto d-block" />
      <p className="text-center text-white">
        RULE BOOK
        <br />
        Click on the button below to download the latest IBJJF Rule Book (v5.2)
      </p>
      <Button href={ruleBook} download variant="primary" size="lg" className="mx-auto d-block mt-3" style={{width: '200px'}}>Download here</Button>
      <Footer/>
    </div>
  );
  
}

export default RulesPage