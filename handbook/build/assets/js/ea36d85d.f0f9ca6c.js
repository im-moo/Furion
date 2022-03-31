"use strict";(self.webpackChunkfurion=self.webpackChunkfurion||[]).push([[2690],{3905:function(e,t,n){n.d(t,{Zo:function(){return s},kt:function(){return m}});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function p(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var l=r.createContext({}),c=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},s=function(e){var t=c(e.components);return r.createElement(l.Provider,{value:t},e.children)},d={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},u=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,i=e.originalType,l=e.parentName,s=p(e,["components","mdxType","originalType","parentName"]),u=c(n),m=a,v=u["".concat(l,".").concat(m)]||u[m]||d[m]||i;return n?r.createElement(v,o(o({ref:t},s),{},{components:n})):r.createElement(v,o({ref:t},s))}));function m(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var i=n.length,o=new Array(i);o[0]=u;var p={};for(var l in t)hasOwnProperty.call(t,l)&&(p[l]=t[l]);p.originalType=e,p.mdxType="string"==typeof e?e:a,o[1]=p;for(var c=2;c<i;c++)o[c]=n[c];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}u.displayName="MDXCreateElement"},5431:function(e,t,n){n.r(t),n.d(t,{assets:function(){return s},contentTitle:function(){return l},default:function(){return m},frontMatter:function(){return p},metadata:function(){return c},toc:function(){return d}});var r=n(3117),a=n(102),i=(n(7294),n(3905)),o=["components"],p={id:"virtual-deploy",title:"34.4 \u4e8c\u7ea7\u865a\u62df\u76ee\u5f55\u90e8\u7f72",sidebar_label:"34.4 \u4e8c\u7ea7\u865a\u62df\u76ee\u5f55\u90e8\u7f72"},l=void 0,c={unversionedId:"virtual-deploy",id:"virtual-deploy",title:"34.4 \u4e8c\u7ea7\u865a\u62df\u76ee\u5f55\u90e8\u7f72",description:"34.4.1 \u5173\u4e8e\u4e8c\u7ea7\u865a\u62df\u76ee\u5f55",source:"@site/docs/virtual-deploy.mdx",sourceDirName:".",slug:"/virtual-deploy",permalink:"/furion/docs/virtual-deploy",editUrl:"https://gitee.com/dotnetchina/Furion/tree/net6/handbook/docs/virtual-deploy.mdx",tags:[],version:"current",lastUpdatedBy:"MonkSoul",lastUpdatedAt:1648527928,formattedLastUpdatedAt:"3/29/2022",frontMatter:{id:"virtual-deploy",title:"34.4 \u4e8c\u7ea7\u865a\u62df\u76ee\u5f55\u90e8\u7f72",sidebar_label:"34.4 \u4e8c\u7ea7\u865a\u62df\u76ee\u5f55\u90e8\u7f72"},sidebar:"docs",previous:{title:"34.3 \u5728 Nginx \u90e8\u7f72",permalink:"/furion/docs/deploy-nginx"},next:{title:"35.1 Docker \u73af\u5883\u6301\u7eed\u90e8\u7f72",permalink:"/furion/docs/deploy-docker-auto"}},s={},d=[{value:"34.4.1 \u5173\u4e8e\u4e8c\u7ea7\u865a\u62df\u76ee\u5f55",id:"3441-\u5173\u4e8e\u4e8c\u7ea7\u865a\u62df\u76ee\u5f55",level:2},{value:"34.4.1.1 \u914d\u7f6e <code>AppSettings</code>",id:"34411-\u914d\u7f6e-appsettings",level:3},{value:"34.4.2 <code>.NET6 WebApplication \u6a21\u5f0f\u4e0b\u865a\u62df\u76ee\u5f55\u914d\u7f6e</code>",id:"3442-net6-webapplication-\u6a21\u5f0f\u4e0b\u865a\u62df\u76ee\u5f55\u914d\u7f6e",level:3},{value:"34.4.3 \u53cd\u9988\u4e0e\u5efa\u8bae",id:"3443-\u53cd\u9988\u4e0e\u5efa\u8bae",level:2}],u={toc:d};function m(e){var t=e.components,n=(0,a.Z)(e,o);return(0,i.kt)("wrapper",(0,r.Z)({},u,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h2",{id:"3441-\u5173\u4e8e\u4e8c\u7ea7\u865a\u62df\u76ee\u5f55"},"34.4.1 \u5173\u4e8e\u4e8c\u7ea7\u865a\u62df\u76ee\u5f55"),(0,i.kt)("p",null,"\u901a\u5e38\u6211\u4eec\u7684\u7ad9\u70b9\u90fd\u662f\u90e8\u7f72\u5728\u7f51\u7ad9\u7684\u6839\u76ee\u5f55\u4e0b\u7684\uff0c\u4f46\u662f\u6709\u4e9b\u65f6\u5019\uff0c\u6211\u4eec\u53ef\u80fd\u5c06\u7f51\u7ad9\u6839\u76ee\u5f55\u4e0b\u7684\u76ee\u5f55\u4f5c\u4e3a\u4e8c\u7ea7\u7ad9\u70b9\u6216\u5b50\u7ad9\u70b9\uff0c\u8fd9\u4e2a\u65f6\u5019\uff0c\u5c31\u4f1a\u51fa\u73b0 ",(0,i.kt)("inlineCode",{parentName:"p"},"404")," \u9519\u8bef\u4e86\u3002"),(0,i.kt)("p",null,"\u8fd9\u4e2a\u65f6\u5019\u5c31\u9700\u8981\u8fdb\u884c\u4e00\u4e9b\u7279\u6b8a\u914d\u7f6e\u4e86\u3002"),(0,i.kt)("h3",{id:"34411-\u914d\u7f6e-appsettings"},"34.4.1.1 \u914d\u7f6e ",(0,i.kt)("inlineCode",{parentName:"h3"},"AppSettings")),(0,i.kt)("p",null,"\u6211\u4eec\u53ea\u9700\u8981\u914d\u7f6e ",(0,i.kt)("inlineCode",{parentName:"p"},"AppSettings")," \u5373\u53ef\uff1a"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-json"},'{\n  "AppSettings": {\n    "VirtualPath": "/\u865a\u62df\u76ee\u5f55"\n  }\n}\n')),(0,i.kt)("h3",{id:"3442-net6-webapplication-\u6a21\u5f0f\u4e0b\u865a\u62df\u76ee\u5f55\u914d\u7f6e"},"34.4.2 ",(0,i.kt)("inlineCode",{parentName:"h3"},".NET6 WebApplication \u6a21\u5f0f\u4e0b\u865a\u62df\u76ee\u5f55\u914d\u7f6e")),(0,i.kt)("div",{className:"admonition admonition-important alert alert--info"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"\u7248\u672c\u8bf4\u660e")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"\u4ee5\u4e0b\u5185\u5bb9\u4ec5\u9650 ",(0,i.kt)("inlineCode",{parentName:"p"},"Furion 3.1.3 +")," \u7248\u672c\u4f7f\u7528\u3002"))),(0,i.kt)("p",null,"\u7531\u4e8e\u5728 ",(0,i.kt)("inlineCode",{parentName:"p"},".NET6")," \u7684 ",(0,i.kt)("inlineCode",{parentName:"p"},"WebApplication")," \u6a21\u5f0f\u4e0b\u5fae\u8f6f\u5e95\u5c42\u53d1\u751f\u4e86\u6539\u53d8\uff0c",(0,i.kt)("strong",{parentName:"p"},"\u6240\u4ee5\u9700\u8981\u4f7f\u7528 ",(0,i.kt)("inlineCode",{parentName:"strong"},"app.UseVirtualPath()")," \u5305\u88f9 ",(0,i.kt)("inlineCode",{parentName:"strong"},"app.UseInject()")," \u548c ",(0,i.kt)("inlineCode",{parentName:"strong"},"app.MapRouteControllers()")),"\uff1a"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-cs",metastring:"{1,4}","{1,4}":!0},"app.UseVirtualPath(app =>\n{\n    app.UseInject(String.Empty);  // \u6ce8\u610f String.Empty \u53ea\u662f\u4f8b\u5b50\uff0c\u53ef\u4ee5\u4e0d\u586b\u6216\u586b\u5176\u4ed6\u7684\uff0c\u89c1\u4e00\u5206\u949f\u5165\u95e8\n    app.MapRouteControllers();\n});\n")),(0,i.kt)("p",null,"**\u6ce8\u610f\uff0c",(0,i.kt)("inlineCode",{parentName:"p"},"app.MapRouteControllers()")," \u662f\u66ff\u6362 ",(0,i.kt)("inlineCode",{parentName:"p"},"app.MapControllers()")," \u7684\uff01"),(0,i.kt)("h2",{id:"3443-\u53cd\u9988\u4e0e\u5efa\u8bae"},"34.4.3 \u53cd\u9988\u4e0e\u5efa\u8bae"),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"\u4e0e\u6211\u4eec\u4ea4\u6d41")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"\u7ed9 Furion \u63d0 ",(0,i.kt)("a",{parentName:"p",href:"https://gitee.com/dotnetchina/Furion/issues/new?issue"},"Issue"),"\u3002"))))}m.isMDXComponent=!0}}]);