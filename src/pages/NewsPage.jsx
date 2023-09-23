import React from 'react'
import News from '../components/News/News'
import Footer from '../components/Footer/Footer'

function NewsPage() {
  return (
    <div style={{ paddingTop: '80px', backgroundColor: '#5c8374', minHeight: '100vh' }}>
      <News/>
      <Footer backgroundColor="#5c8374" />
    </div>
  )
}

export default NewsPage