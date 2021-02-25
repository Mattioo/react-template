import { connect } from 'react-redux';
import NavbarTemplate from './navbar-template';
import NavbarActions from '../../Actions/navbar';
import { withRouter } from 'react-router-dom';

const mapStateToProps = (state) => {
    return {
        pathInState: state.navbar.path,
        language: state.header.language.set
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        changePathInState: (path) => {
            return dispatch({ type: NavbarActions.CHANGE_PATH_IN_STATE, path });
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