import React from 'react'
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import './Timer.css'

function Timer() {
    return (
        <Container fluid>
            <Row className="bg-dark text-white">
                <Col xs={9}>
                    <h2 className='competitor-name'>
                        {/* {competitorName.length > 22 ? competitorName.slice(0, 19) + '...' : competitorName} */}
                        Guțu Șăineanu
                    </h2>
                    <p className='team-name text-secondary'>Team Name</p>
                </Col>
                <Col xs={1} className="d-flex flex-column text-center">
                    <p className="text-secondary caption-size m-0">Advantage</p>
                    <p className="text-secondary advantage-size m-0">0</p>
                    <p className="text-secondary caption-size m-0">Penalty</p>
                    <p className="text-secondary advantage-size m-0">0</p>
                </Col>
                <Col xs={2} className="bg-danger d-flex align-items-center justify-content-center">
                    <h1 className='points-size'>
                        10
                    </h1>
                </Col>
            </Row>
            <Row className="bg-dark text-white">
                <Col xs={9}>
                    <h2 className='competitor-name'>
                        {/* {competitorName.length > 22 ? competitorName.slice(0, 19) + '...' : competitorName} */}
                        Gheorghe Dumitrescu
                    </h2>
                    <p className='team-name text-secondary'>Team Name</p>
                </Col >
                <Col xs={1} className="d-flex flex-column text-center">
                    <p className="text-secondary caption-size m-0">Advantage</p>
                    <p className="text-secondary advantage-size m-0">0</p>
                    <p className="text-secondary caption-size m-0">Penalty</p>
                    <p className="text-secondary advantage-size m-0">0</p>
                </Col>
                <Col xs={2} className="bg-primary d-flex align-items-center justify-content-center">
                    <h1 className='points-size'>0</h1>
                </Col>
            </Row>
            <Row className="bg-dark text-white">
                <Col className='d-flex align-items-center'>
                    <h2 className='category-size'>Adults/ Male/ -85kg</h2>
                </Col>
                <Col className="text-end">
                    <h1 className='timer-size'>00:00</h1>
                </Col>
            </Row>
        </Container>
    )
}

export default Timer