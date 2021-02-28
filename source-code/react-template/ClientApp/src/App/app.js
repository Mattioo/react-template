import { connect } from 'react-redux';
import AppTemplate from './app-template';

const mapStateToProps = (state) => {
    return {
        fontSize: state.header.fontSize
    };
}

const App = connect(mapStateToProps)(AppTemplate);

export default App;