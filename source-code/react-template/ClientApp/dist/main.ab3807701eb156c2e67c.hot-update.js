webpackHotUpdate("main",{

/***/ "./src/components/app/index.jsx":
/*!**************************************!*\
  !*** ./src/components/app/index.jsx ***!
  \**************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/slicedToArray */ "./node_modules/@babel/runtime/helpers/slicedToArray.js");
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! react */ "./node_modules/react/index.js");
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _toolbar__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../toolbar */ "./src/components/toolbar/index.jsx");
/* harmony import */ var _styles__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../styles */ "./src/styles.js");



/* STYLE DO PRZEBUDOWANIA */



var App = function App() {
  var _useState = Object(react__WEBPACK_IMPORTED_MODULE_1__["useState"])(100),
      _useState2 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_useState, 2),
      fontSize = _useState2[0],
      setFontSize = _useState2[1];

  var _useState3 = Object(react__WEBPACK_IMPORTED_MODULE_1__["useState"])(false),
      _useState4 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_useState3, 2),
      contrast = _useState4[0],
      setContrast = _useState4[1];

  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement(react__WEBPACK_IMPORTED_MODULE_1___default.a.Fragment, null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "".concat(contrast ? 'app-content app-content--contrast' : 'app-content'),
    style: {
      fontSize: "".concat(fontSize, "%")
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement(_toolbar__WEBPACK_IMPORTED_MODULE_2__["default"], {
    fontSize: fontSize,
    setFontSize: setFontSize,
    contrast: contrast,
    setContrast: setContrast
  })));
};

/* harmony default export */ __webpack_exports__["default"] = (App);

/***/ })

})
//# sourceMappingURL=main.ab3807701eb156c2e67c.hot-update.js.map