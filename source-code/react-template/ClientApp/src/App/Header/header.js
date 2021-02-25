import { connect } from 'react-redux';
import HeaderTemplate from './header-template';
import HeaderActions from '../../Actions/header';

const mapStateToProps = (state) => {
    return {
        language: state.header.language,
        contrast: state.header.contrast,
        fontSize: state.header.fontSize
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        changeLanguage: (language) => {
            return dispatch({ type: HeaderActions.CHANGE_LANGUAGE, language });
        },
        toogleContrast: (value) => {
            return dispatch({ type: HeaderActions.CHANGE_CONTRAST, contrast: value });
        },
        changeFontSize: (size) => {
            return dispatch({ type: HeaderActions.CHANGE_FONT_SIZE, fontSize: Math.min(Math.max(100, size), 130) });
        }
    }
}

const Header = connect(
    mapStateToProps,
    mapDispatchToProps
)(HeaderTemplate);

export default Header;