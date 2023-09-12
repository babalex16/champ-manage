import React from 'react'
import "./Carousel.css"
import Carousel from 'react-bootstrap/Carousel'
import FirstCarouselImage from '../../assets/photos/banner.jpg'
import SecondCarouselImage from '../../assets/photos/banner.jpg'
import ThirdCarouselImage from '../../assets/photos/banner.jpg'

function CustomCarousel() {
  return (
        <Carousel>
            <Carousel.Item>
                <img
                    className='d-block w-100 carousel-image'
                    src={FirstCarouselImage}
                    alt="First slide"
                />
            </Carousel.Item>
            <Carousel.Item>
                <img
                    className='d-block w-100 carousel-image'
                    src={SecondCarouselImage}
                    alt="Second slide"
                />
            </Carousel.Item>
            <Carousel.Item>
                <img
                    className='d-block w-100 carousel-image'
                    src={ThirdCarouselImage}
                    alt="Third slide"
                />
            </Carousel.Item>
        </Carousel>
    )
}

export default CustomCarousel