import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Route, Switch, Redirect } from 'react-router-dom';
import Layout from './components/Layout/Layout';
import HomePage from './components/HomePage/HomePage';
import HistoryPage from './components/HistoryPage/HistoryPage';
import ErrorPage from './components/ErrorPage/ErrorPage';

function App() {
  return (
    <div className="App">
      <Router>
        <Layout>
          <Switch>
            <Route exact path='/'>
              <HomePage></HomePage>
            </Route>
            <Route path='/history'>
              <HistoryPage></HistoryPage>
            </Route>
            <Route path='*'>
              <ErrorPage></ErrorPage>
            </Route>
          </Switch>
        </Layout>
      </Router>
    </div>
  );
}

export default App;
