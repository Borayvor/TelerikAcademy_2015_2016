"use strict";

let phones = [
    {
        name: 'Samsung Galaxy s5',
        imgUrl: 'http://images.samsung.com/is/image/samsung/bg_SM-G900FZNABGL_001_front_black?$DT-Gallery$',
        price: 800
    },
    {
        name: 'Samsung Galaxy s6',
        imgUrl: 'http://images.samsung.com/is/image/samsung/bg_SM-G920FZKABGL_008_Front_black?$DT-Gallery$',
        price: 1200
    },
    {
        name: 'Nokia lumia 630',
        imgUrl: 'https://i-1.prod-cdn.webapps.microsoft.com/r/image/view/-/3691696/extraHighRes/1/-/Nokia-Lumia-630-hero-jpg.jpg',
        price: 500
    },
    {
        name: 'Nokia',
        imgUrl: 'http://cdn1.knowyourmobile.com/sites/knowyourmobilecom/files/styles/gallery_wide/public/2/99/6110.jpg?itok=cFH-zVOm',
        price: 1000
    },
];

let tablets = [
    {
        name: 'Lenovo Yoga',
        imgUrl: 'http://static.indianexpress.com/m-images/M_Id_439619_Lenovo_Yoga_tablet.jpg',
        price: 100
    },
    {
        name: 'One',
        imgUrl: 'http://static.acer.com/up/Resource/Acer/Laptops/Acer_One_10/Images/20150515/Acer_One_10_Preview.png',
        price: 150
    },
    {
        name: 'Predator',
        imgUrl: 'http://cdn.slashgear.com/wp-content/uploads/2015/09/acer-predator-8-ifa-2015-sg-1-1280x720.jpg',
        price: 987
    }
];

let wearables = [
    {
        name: 'Sony watches',
        imgUrl: 'http://usa.chinadaily.com.cn/world/attachement/jpg/site1/20130919/180373cf843213a5661641.jpg',
        price: 300
    },
    {
        name: 'Black and purple headphones',
        imgUrl: 'http://www.gadgetreview.com/wp-content/uploads/2014/04/STREAMZ-01.jpg',
        price: 500
    },
    {
        name: 'Google Glass',
        imgUrl: 'http://www.wired.com/images_blogs/gadgetlab/2014/01/20140124-GOOGLE-GLASS-FRAMES-0018.jpg',
        price: 100
    }
];

module.exports = {
    phones: phones,
    tablets: tablets,
    wearables: wearables
}