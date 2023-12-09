import { Bracket } from 'react-brackets';
import React from 'react';
import { Container } from 'react-bootstrap';


const rounds = [
  {
    id: 1,
    title: 'Round one',
    seeds: [
      {
        id: 1,
        date: new Date().toDateString(),
        teams: [{ name: 'Team A' }, { name: 'Team B' }],
      },
      {
        id: 2,
        date: new Date().toDateString(),
        teams: [{ name: 'Team C' }, { name: 'Team D' }],
      },
    ],
  },
  {
    id: 2,
    title: 'Round two',
    seeds: [
      {
        id: 3,
        date: new Date().toDateString(),
        teams: [{ name: 'Team A' }, { name: 'Team C' }],
      },
    ],
  },
];

const Brackets = (props) => {
  
  return (
    <Container style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
      <Bracket
      rounds={rounds}
      roundTitleComponent={(title, roundIndex) => {
        return <div key={roundIndex}style={{ textAlign: 'center', color: 'white' }}>{title}</div>;
      }}
    />
    </Container>
    
  );
};


export default Brackets;

