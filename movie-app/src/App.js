import './App.scss';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import MovieHandling from './components/movie/MovieHandling';
import Header from './components/Shared/Header';
import Container from 'react-bootstrap/Container';
import Footer from './components/Shared/Footer';
function App() {
  return (
    <div className="App">
    <Header />
    <Container>
    <Router>
    <Switch>
    <Route path="/" exact component={MovieHandling} />
    </Switch>
    </Router>
  </Container>
  <Footer />
  </div>
  );
}

export default App;
