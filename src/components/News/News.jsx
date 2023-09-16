import React from 'react'
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import './News.css'
import bannerImage from '../../assets/photos/banner.jpg';

const newsData = [
  {
    imageSrc: bannerImage, 
    date: '20-09-2023',
    text: 'This is the content of card 1.',
    link: '#',
  },
  {
    imageSrc: bannerImage, 
    date: '05-10-2023',
    text: 'This is the content of card 1.',
    link: '#',
  },
  {
    imageSrc: bannerImage,
    date: '15-11-2023',
    text: 'This is the content of card 1.',
    link: '#',
  },
  {
    imageSrc: bannerImage,
    date: '15-11-2023',
    text: 'This is the content of card 1.',
    link: '#',
  },
];

function News() {
  return (
    <div className='news-background'>
      <div className='news-container'>
        <div>
          <h3 className='text-white text-uppercase text-center customFont my-5'>Recent News</h3>
          <Row xs={1} md={2} xl={4} className="g-3">
            {newsData.map((news, idx) => (
              <Col key={idx}>
                  <Card className='news-card my-3 mx-3 px-0'>
                    <a href={news.link} > {}
                      <Card.Img variant="top" src={news.imageSrc} />
                    </a>
                    <Card.Body>
                      <Card.Text className='text-white text-center'>
                        DATE OF THE EVENT: &nbsp;&nbsp;&nbsp; {news.date}
                      </Card.Text>
                    </Card.Body>
                  </Card>
              </Col>
            ))}
          </Row>
        </div>
      </div>
      <div className='text-center py-5'>
        <Button href="/news" variant="outline-light" size="md" className='customFont '>
          ALL NEWS
        </Button>
      </div>
    </div>
  )
}

export default News