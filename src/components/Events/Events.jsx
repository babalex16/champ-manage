import React from 'react'
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import './Events.css'
import bannerImage from '../../assets/photos/banner.jpg';

const eventData = [
  {
    imageSrc: bannerImage, 
    date: '20-09-2023',
    link: '/event',
  },
  {
    imageSrc: bannerImage, 
    date: '05-10-2023',
    link: '/event',
  },
  {
    imageSrc: bannerImage,
    date: '15-11-2023',
    link: '/event',
  },
  {
    imageSrc: bannerImage,
    date: '15-11-2023',
    link: '#',
  },
];

function Events() {
  return (
      <section id='events' className='events-background'>
        <div className='events-container'>
          <div>
            <h3 className='text-white text-uppercase text-center customFont my-5'>Upcoming events</h3>
            <Row xs={1} md={2} xl={4} className="g-3">
              {eventData.map((event, idx) => (
                <Col key={idx}>
                    <Card className='event-card my-3 mx-3 px-0'>
                      <a href={event.link} > {}
                        <Card.Img variant="top" src={event.imageSrc} />
                      </a>
                      <Card.Body>
                        <Card.Text className='text-white text-center'>
                          DATE OF THE EVENT: &nbsp;&nbsp;&nbsp; {event.date}
                        </Card.Text>
                      </Card.Body>
                    </Card>
                </Col>
              ))}
            </Row>
          </div>
        </div>
      </section>
  );
}

export default Events