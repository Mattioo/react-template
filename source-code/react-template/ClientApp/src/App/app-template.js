import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";

import Header from './header/header';
import Navbar from './navbar/navbar';

import './app-styles.scss';

const AppTemplate = (props) => {
    return (
        <>
            <Header />
            <Router>
                <div style={{ fontSize: `${props.fontSize}%` }}>
                    <Navbar />
                    <div className='container'>
                        <Switch>
                            <Route path="/contact">
                                <div>Kontakt</div>
                            </Route>
                            <Route path="/info">
                                <div>Informacje</div>
                            </Route>
                            <Route path="/">
                                <div>Strona główna</div>
                            </Route>
                        </Switch>
                    </div>
                </div>
            </Router>
        </>
    );
}

export default AppTemplate;
