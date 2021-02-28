import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

import NavbarTemplate from './navbar-template';
import NavbarActions from '../../actions/navbar';

const mapStateToProps = (state) => {
    return {
        pathInState: state.navbar.path,
        language: state.header.language.set,
        contrast: state.header.contrast
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        changePathInState: (path) => {
            return dispatch({ type: NavbarActions.CHANGE_PATH_IN_STATE, path: path });
        }
    }
}

const NavbarComponent = connect(
    mapStateToProps,
    mapDispatchToProps
)(NavbarTemplate);

const Navbar = withRouter(
    props => <NavbarComponent {...props} />
);

export default Navbar;