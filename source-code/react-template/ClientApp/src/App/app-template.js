import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";

import Header from './Header/header';
import Navbar from './Navbar/navbar';

const AppTemplate = (props) => {
    return (
        <>
            <Header />
            <Router>
                <div style={{ fontSize: `${props.fontSize}%` }}>
                    <Navbar />
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
            </Router>
        </>
    );
}

export default AppTemplate;
