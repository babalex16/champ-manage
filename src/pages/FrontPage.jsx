import React from 'react'
import Button from 'react-bootstrap/Button';
import CustomCarousel from '../components/Carousel/CustomCarousel'
import Events from '../components/Championships/Championships'
import News from '../components/News/News'
import Footer from '../components/Footer/Footer'

function FrontPage() {
  return (
    <>
      <CustomCarousel />
      <Events />
      <div className='text-center py-5' style={{ backgroundColor: '#183D3D' }}>
        <Button href="/events" variant="outline-light" size="md" style={{ fontFamily: 'Roboto, sans-serif' }}>
          ALL CHAMPIONSHIPS
        </Button>
      </div>
      <News />
      <div className='text-center py-5' style={{ backgroundColor: '#5c8374' }}>
        <Button href="/news" variant="outline-light" size="md" style={{ fontFamily: 'Roboto, sans-serif' }}>
          ALL NEWS
        </Button>
      </div>
      <Footer />
    </>
  )
}

export default FrontPage