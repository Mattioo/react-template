webpackHotUpdate("main",{

/***/ "./src/index.jsx":
/*!***********************!*\
  !*** ./src/index.jsx ***!
  \***********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* WEBPACK VAR INJECTION */(function(module) {/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ "./node_modules/react/index.js");
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var react_dom__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! react-dom */ "./node_modules/react-dom/index.js");
/* harmony import */ var react_dom__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(react_dom__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _components_app__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/app */ "./src/components/app/index.jsx");
__webpack_require__(/*! ./favicon.ico */ "./src/favicon.ico");





var config = function () {
  return __webpack_require__(/*! ./config.json */ "./src/config.json");
}();

var url = "".concat(window.location.protocol, "//").concat(window.location.host);
var stylesLink = document.head.querySelector('link[href="//:0"]');
fetch("".concat(config.backoffice.url, "/").concat(config.backoffice.paths.styles, "?url=").concat(url)).then(function (resp) {
  return resp.json();
}).then(function (styles) {
  if (styles.status === 200) {
    if (stylesLink) {
      stylesLink.setAttribute('href', "./styles/".concat(styles.dict, "/").concat(styles.file));
    }
  } else {
    throw 'Not Found';
  }
})["catch"](function () {
  if (stylesLink) {
    stylesLink.setAttribute('href', "./styles/default/bundle.css?v=".concat(new Date().getTime()));
    console.error('Załadowano style domyślne');
  }
})["finally"](function () {
  react_dom__WEBPACK_IMPORTED_MODULE_1___default.a.render( /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(_components_app__WEBPACK_IMPORTED_MODULE_2__["default"], null), document.getElementById('app'));
});
if (module && module.hot) module.hot.accept();
/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./../node_modules/webpack/buildin/harmony-module.js */ "./node_modules/webpack/buildin/harmony-module.js")(module)))

/***/ })

})
//# sourceMappingURL=main.37370015d082c05eda69.hot-update.js.map