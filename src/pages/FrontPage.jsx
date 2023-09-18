import React from 'react'
import CustomCarousel from '../components/Carousel/CustomCarousel'
import Events from '../components/Events/Events'
import News from '../components/News/News'
import Footer from '../components/Footer/Footer'

function FrontPage() {
  return (
    <>
      <CustomCarousel/>
      <Events/>
      <News/>
      <Footer/>
    </>
  )
}

export default FrontPage