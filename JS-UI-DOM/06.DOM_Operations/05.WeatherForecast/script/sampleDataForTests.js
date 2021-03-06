var data = JSON.parse(`{
    "cod": "200",
    "message": 0.0233,
    "cnt": 40,
    "list": [{
        "dt": 1488920400,
        "main": {
            "temp": 280.49,
            "temp_min": 278.619,
            "temp_max": 280.49,
            "pressure": 922.38,
            "sea_level": 1018.84,
            "grnd_level": 922.38,
            "humidity": 82,
            "temp_kf": 1.87
        },
        "weather": [{
            "id": 803,
            "main": "Clouds",
            "description": "broken clouds",
            "icon": "04n"
        }],
        "clouds": {
            "all": 80
        },
        "wind": {
            "speed": 2.91,
            "deg": 107.509
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-07 21:00:00"
    }, {
        "dt": 1488931200,
        "main": {
            "temp": 279.41,
            "temp_min": 278.01,
            "temp_max": 279.41,
            "pressure": 921.94,
            "sea_level": 1018.61,
            "grnd_level": 921.94,
            "humidity": 92,
            "temp_kf": 1.4
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 56
        },
        "wind": {
            "speed": 3.01,
            "deg": 93.5014
        },
        "rain": {
            "3h": 0.085
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-08 00:00:00"
    }, {
        "dt": 1488942000,
        "main": {
            "temp": 280.07,
            "temp_min": 279.135,
            "temp_max": 280.07,
            "pressure": 922.78,
            "sea_level": 1019.81,
            "grnd_level": 922.78,
            "humidity": 100,
            "temp_kf": 0.93
        },
        "weather": [{
            "id": 501,
            "main": "Rain",
            "description": "moderate rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 4.17,
            "deg": 101.502
        },
        "rain": {
            "3h": 3.74
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-08 03:00:00"
    }, {
        "dt": 1488952800,
        "main": {
            "temp": 278.96,
            "temp_min": 278.492,
            "temp_max": 278.96,
            "pressure": 923.8,
            "sea_level": 1021.06,
            "grnd_level": 923.8,
            "humidity": 97,
            "temp_kf": 0.47
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 88
        },
        "wind": {
            "speed": 4.42,
            "deg": 99.0014
        },
        "rain": {
            "3h": 0.45
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-08 06:00:00"
    }, {
        "dt": 1488963600,
        "main": {
            "temp": 280.253,
            "temp_min": 280.253,
            "temp_max": 280.253,
            "pressure": 925.25,
            "sea_level": 1021.99,
            "grnd_level": 925.25,
            "humidity": 93,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 48
        },
        "wind": {
            "speed": 4.32,
            "deg": 95.5013
        },
        "rain": {
            "3h": 0.335
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-08 09:00:00"
    }, {
        "dt": 1488974400,
        "main": {
            "temp": 282.735,
            "temp_min": 282.735,
            "temp_max": 282.735,
            "pressure": 925.49,
            "sea_level": 1021.69,
            "grnd_level": 925.49,
            "humidity": 84,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 4.46,
            "deg": 81.5015
        },
        "rain": {
            "3h": 0.115
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-08 12:00:00"
    }, {
        "dt": 1488985200,
        "main": {
            "temp": 282.062,
            "temp_min": 282.062,
            "temp_max": 282.062,
            "pressure": 926.41,
            "sea_level": 1022.49,
            "grnd_level": 926.41,
            "humidity": 87,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 3.77,
            "deg": 53.5006
        },
        "rain": {
            "3h": 0.28
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-08 15:00:00"
    }, {
        "dt": 1488996000,
        "main": {
            "temp": 280.702,
            "temp_min": 280.702,
            "temp_max": 280.702,
            "pressure": 928.08,
            "sea_level": 1024.75,
            "grnd_level": 928.08,
            "humidity": 91,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 3.87,
            "deg": 46.0009
        },
        "rain": {
            "3h": 0.41
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-08 18:00:00"
    }, {
        "dt": 1489006800,
        "main": {
            "temp": 280.201,
            "temp_min": 280.201,
            "temp_max": 280.201,
            "pressure": 928.77,
            "sea_level": 1026.11,
            "grnd_level": 928.77,
            "humidity": 91,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 56
        },
        "wind": {
            "speed": 2.94,
            "deg": 42.0023
        },
        "rain": {
            "3h": 0.23
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-08 21:00:00"
    }, {
        "dt": 1489017600,
        "main": {
            "temp": 277.793,
            "temp_min": 277.793,
            "temp_max": 277.793,
            "pressure": 929.41,
            "sea_level": 1027.31,
            "grnd_level": 929.41,
            "humidity": 94,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 64
        },
        "wind": {
            "speed": 2.11,
            "deg": 22.5007
        },
        "rain": {
            "3h": 0.029999999999999
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-09 00:00:00"
    }, {
        "dt": 1489028400,
        "main": {
            "temp": 275.961,
            "temp_min": 275.961,
            "temp_max": 275.961,
            "pressure": 930.21,
            "sea_level": 1028.57,
            "grnd_level": 930.21,
            "humidity": 100,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 80
        },
        "wind": {
            "speed": 1.52,
            "deg": 14.0045
        },
        "rain": {
            "3h": 0.38
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-09 03:00:00"
    }, {
        "dt": 1489039200,
        "main": {
            "temp": 275.896,
            "temp_min": 275.896,
            "temp_max": 275.896,
            "pressure": 931.64,
            "sea_level": 1030.32,
            "grnd_level": 931.64,
            "humidity": 100,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 68
        },
        "wind": {
            "speed": 1.58,
            "deg": 16.5001
        },
        "rain": {
            "3h": 0.07
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-09 06:00:00"
    }, {
        "dt": 1489050000,
        "main": {
            "temp": 279.337,
            "temp_min": 279.337,
            "temp_max": 279.337,
            "pressure": 932.45,
            "sea_level": 1030.62,
            "grnd_level": 932.45,
            "humidity": 88,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 44
        },
        "wind": {
            "speed": 2.3,
            "deg": 26.0007
        },
        "rain": {
            "3h": 0.03
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-09 09:00:00"
    }, {
        "dt": 1489060800,
        "main": {
            "temp": 282.359,
            "temp_min": 282.359,
            "temp_max": 282.359,
            "pressure": 931.7,
            "sea_level": 1029.3,
            "grnd_level": 931.7,
            "humidity": 74,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 12
        },
        "wind": {
            "speed": 3.25,
            "deg": 27.5012
        },
        "rain": {
            "3h": 0.0099999999999998
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-09 12:00:00"
    }, {
        "dt": 1489071600,
        "main": {
            "temp": 281.195,
            "temp_min": 281.195,
            "temp_max": 281.195,
            "pressure": 931.73,
            "sea_level": 1029.13,
            "grnd_level": 931.73,
            "humidity": 69,
            "temp_kf": 0
        },
        "weather": [{
            "id": 801,
            "main": "Clouds",
            "description": "few clouds",
            "icon": "02d"
        }],
        "clouds": {
            "all": 24
        },
        "wind": {
            "speed": 3.04,
            "deg": 27.0022
        },
        "rain": {},
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-09 15:00:00"
    }, {
        "dt": 1489082400,
        "main": {
            "temp": 277.053,
            "temp_min": 277.053,
            "temp_max": 277.053,
            "pressure": 932.99,
            "sea_level": 1030.87,
            "grnd_level": 932.99,
            "humidity": 79,
            "temp_kf": 0
        },
        "weather": [{
            "id": 803,
            "main": "Clouds",
            "description": "broken clouds",
            "icon": "04n"
        }],
        "clouds": {
            "all": 76
        },
        "wind": {
            "speed": 1.47,
            "deg": 10.0032
        },
        "rain": {},
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-09 18:00:00"
    }, {
        "dt": 1489093200,
        "main": {
            "temp": 276.065,
            "temp_min": 276.065,
            "temp_max": 276.065,
            "pressure": 932.74,
            "sea_level": 1030.94,
            "grnd_level": 932.74,
            "humidity": 83,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 76
        },
        "wind": {
            "speed": 0.94,
            "deg": 350.501
        },
        "rain": {
            "3h": 0.03
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-09 21:00:00"
    }, {
        "dt": 1489104000,
        "main": {
            "temp": 273.211,
            "temp_min": 273.211,
            "temp_max": 273.211,
            "pressure": 931.69,
            "sea_level": 1030.15,
            "grnd_level": 931.69,
            "humidity": 92,
            "temp_kf": 0
        },
        "weather": [{
            "id": 802,
            "main": "Clouds",
            "description": "scattered clouds",
            "icon": "03n"
        }],
        "clouds": {
            "all": 48
        },
        "wind": {
            "speed": 0.91,
            "deg": 252.011
        },
        "rain": {},
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-10 00:00:00"
    }, {
        "dt": 1489114800,
        "main": {
            "temp": 275.178,
            "temp_min": 275.178,
            "temp_max": 275.178,
            "pressure": 930.83,
            "sea_level": 1029.25,
            "grnd_level": 930.83,
            "humidity": 88,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 88
        },
        "wind": {
            "speed": 1.51,
            "deg": 263.5
        },
        "rain": {
            "3h": 0.06
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-10 03:00:00"
    }, {
        "dt": 1489125600,
        "main": {
            "temp": 275.931,
            "temp_min": 275.931,
            "temp_max": 275.931,
            "pressure": 930.86,
            "sea_level": 1029.16,
            "grnd_level": 930.86,
            "humidity": 96,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 68
        },
        "wind": {
            "speed": 1.73,
            "deg": 268
        },
        "rain": {
            "3h": 0.08
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-10 06:00:00"
    }, {
        "dt": 1489136400,
        "main": {
            "temp": 280.327,
            "temp_min": 280.327,
            "temp_max": 280.327,
            "pressure": 929.96,
            "sea_level": 1027.31,
            "grnd_level": 929.96,
            "humidity": 80,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 24
        },
        "wind": {
            "speed": 2.27,
            "deg": 278.002
        },
        "rain": {
            "3h": 0.02
        },
        "snow": {
            "3h": 0.005
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-10 09:00:00"
    }, {
        "dt": 1489147200,
        "main": {
            "temp": 282.489,
            "temp_min": 282.489,
            "temp_max": 282.489,
            "pressure": 928.36,
            "sea_level": 1024.86,
            "grnd_level": 928.36,
            "humidity": 69,
            "temp_kf": 0
        },
        "weather": [{
            "id": 801,
            "main": "Clouds",
            "description": "few clouds",
            "icon": "02d"
        }],
        "clouds": {
            "all": 12
        },
        "wind": {
            "speed": 3.72,
            "deg": 287.501
        },
        "rain": {},
        "snow": {},
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-10 12:00:00"
    }, {
        "dt": 1489158000,
        "main": {
            "temp": 280.476,
            "temp_min": 280.476,
            "temp_max": 280.476,
            "pressure": 927.41,
            "sea_level": 1023.97,
            "grnd_level": 927.41,
            "humidity": 69,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 64
        },
        "wind": {
            "speed": 4.26,
            "deg": 292.504
        },
        "rain": {
            "3h": 0.09
        },
        "snow": {},
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-10 15:00:00"
    }, {
        "dt": 1489168800,
        "main": {
            "temp": 277.257,
            "temp_min": 277.257,
            "temp_max": 277.257,
            "pressure": 927.28,
            "sea_level": 1024.66,
            "grnd_level": 927.28,
            "humidity": 96,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 80
        },
        "wind": {
            "speed": 2.9,
            "deg": 277.502
        },
        "rain": {
            "3h": 1.64
        },
        "snow": {},
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-10 18:00:00"
    }, {
        "dt": 1489179600,
        "main": {
            "temp": 276.765,
            "temp_min": 276.765,
            "temp_max": 276.765,
            "pressure": 927.01,
            "sea_level": 1024.73,
            "grnd_level": 927.01,
            "humidity": 95,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 88
        },
        "wind": {
            "speed": 4.52,
            "deg": 296.501
        },
        "rain": {
            "3h": 0.57
        },
        "snow": {
            "3h": 0.005
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-10 21:00:00"
    }, {
        "dt": 1489190400,
        "main": {
            "temp": 275.359,
            "temp_min": 275.359,
            "temp_max": 275.359,
            "pressure": 926.08,
            "sea_level": 1024.31,
            "grnd_level": 926.08,
            "humidity": 83,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 76
        },
        "wind": {
            "speed": 4.96,
            "deg": 299.001
        },
        "rain": {
            "3h": 0.050000000000001
        },
        "snow": {
            "3h": 0.075
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-11 00:00:00"
    }, {
        "dt": 1489201200,
        "main": {
            "temp": 274.454,
            "temp_min": 274.454,
            "temp_max": 274.454,
            "pressure": 924.7,
            "sea_level": 1023.19,
            "grnd_level": 924.7,
            "humidity": 81,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 80
        },
        "wind": {
            "speed": 4.96,
            "deg": 301.502
        },
        "rain": {
            "3h": 0.02
        },
        "snow": {
            "3h": 0.44
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-11 03:00:00"
    }, {
        "dt": 1489212000,
        "main": {
            "temp": 274.424,
            "temp_min": 274.424,
            "temp_max": 274.424,
            "pressure": 924.48,
            "sea_level": 1023.23,
            "grnd_level": 924.48,
            "humidity": 77,
            "temp_kf": 0
        },
        "weather": [{
            "id": 600,
            "main": "Snow",
            "description": "light snow",
            "icon": "13d"
        }],
        "clouds": {
            "all": 88
        },
        "wind": {
            "speed": 4.42,
            "deg": 304.501
        },
        "rain": {},
        "snow": {
            "3h": 0.2
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-11 06:00:00"
    }, {
        "dt": 1489222800,
        "main": {
            "temp": 275.083,
            "temp_min": 275.083,
            "temp_max": 275.083,
            "pressure": 924.66,
            "sea_level": 1023,
            "grnd_level": 924.66,
            "humidity": 76,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 88
        },
        "wind": {
            "speed": 5.22,
            "deg": 317.5
        },
        "rain": {
            "3h": 0.0099999999999998
        },
        "snow": {
            "3h": 0.595
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-11 09:00:00"
    }, {
        "dt": 1489233600,
        "main": {
            "temp": 275.173,
            "temp_min": 275.173,
            "temp_max": 275.173,
            "pressure": 924.55,
            "sea_level": 1022.85,
            "grnd_level": 924.55,
            "humidity": 77,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 4.66,
            "deg": 321.501
        },
        "rain": {
            "3h": 0.039999999999999
        },
        "snow": {
            "3h": 0.99
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-11 12:00:00"
    }, {
        "dt": 1489244400,
        "main": {
            "temp": 274.305,
            "temp_min": 274.305,
            "temp_max": 274.305,
            "pressure": 925.06,
            "sea_level": 1023.32,
            "grnd_level": 925.06,
            "humidity": 82,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10d"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 4.11,
            "deg": 318.503
        },
        "rain": {
            "3h": 0.09
        },
        "snow": {
            "3h": 1.405
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-11 15:00:00"
    }, {
        "dt": 1489255200,
        "main": {
            "temp": 273.776,
            "temp_min": 273.776,
            "temp_max": 273.776,
            "pressure": 926.44,
            "sea_level": 1025.08,
            "grnd_level": 926.44,
            "humidity": 86,
            "temp_kf": 0
        },
        "weather": [{
            "id": 600,
            "main": "Snow",
            "description": "light snow",
            "icon": "13n"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 3.77,
            "deg": 315.502
        },
        "rain": {},
        "snow": {
            "3h": 1.315
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-11 18:00:00"
    }, {
        "dt": 1489266000,
        "main": {
            "temp": 273.626,
            "temp_min": 273.626,
            "temp_max": 273.626,
            "pressure": 927.34,
            "sea_level": 1026.29,
            "grnd_level": 927.34,
            "humidity": 87,
            "temp_kf": 0
        },
        "weather": [{
            "id": 600,
            "main": "Snow",
            "description": "light snow",
            "icon": "13n"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 3.54,
            "deg": 319
        },
        "rain": {},
        "snow": {
            "3h": 1.04
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-11 21:00:00"
    }, {
        "dt": 1489276800,
        "main": {
            "temp": 273.348,
            "temp_min": 273.348,
            "temp_max": 273.348,
            "pressure": 928.28,
            "sea_level": 1027.64,
            "grnd_level": 928.28,
            "humidity": 89,
            "temp_kf": 0
        },
        "weather": [{
            "id": 600,
            "main": "Snow",
            "description": "light snow",
            "icon": "13n"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 2.84,
            "deg": 308.003
        },
        "rain": {},
        "snow": {
            "3h": 0.535
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-12 00:00:00"
    }, {
        "dt": 1489287600,
        "main": {
            "temp": 272.75,
            "temp_min": 272.75,
            "temp_max": 272.75,
            "pressure": 929.18,
            "sea_level": 1028.78,
            "grnd_level": 929.18,
            "humidity": 88,
            "temp_kf": 0
        },
        "weather": [{
            "id": 600,
            "main": "Snow",
            "description": "light snow",
            "icon": "13n"
        }],
        "clouds": {
            "all": 88
        },
        "wind": {
            "speed": 2.46,
            "deg": 294.501
        },
        "rain": {},
        "snow": {
            "3h": 0.395
        },
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-12 03:00:00"
    }, {
        "dt": 1489298400,
        "main": {
            "temp": 273.021,
            "temp_min": 273.021,
            "temp_max": 273.021,
            "pressure": 930.82,
            "sea_level": 1030.52,
            "grnd_level": 930.82,
            "humidity": 86,
            "temp_kf": 0
        },
        "weather": [{
            "id": 600,
            "main": "Snow",
            "description": "light snow",
            "icon": "13d"
        }],
        "clouds": {
            "all": 92
        },
        "wind": {
            "speed": 2.26,
            "deg": 282.505
        },
        "rain": {},
        "snow": {
            "3h": 0.14
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-12 06:00:00"
    }, {
        "dt": 1489309200,
        "main": {
            "temp": 275.84,
            "temp_min": 275.84,
            "temp_max": 275.84,
            "pressure": 932.09,
            "sea_level": 1030.96,
            "grnd_level": 932.09,
            "humidity": 82,
            "temp_kf": 0
        },
        "weather": [{
            "id": 800,
            "main": "Clear",
            "description": "clear sky",
            "icon": "01d"
        }],
        "clouds": {
            "all": 56
        },
        "wind": {
            "speed": 2.16,
            "deg": 290.501
        },
        "rain": {},
        "snow": {
            "3h": 0.02
        },
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-12 09:00:00"
    }, {
        "dt": 1489320000,
        "main": {
            "temp": 278.746,
            "temp_min": 278.746,
            "temp_max": 278.746,
            "pressure": 931.81,
            "sea_level": 1029.92,
            "grnd_level": 931.81,
            "humidity": 75,
            "temp_kf": 0
        },
        "weather": [{
            "id": 802,
            "main": "Clouds",
            "description": "scattered clouds",
            "icon": "03d"
        }],
        "clouds": {
            "all": 32
        },
        "wind": {
            "speed": 1.93,
            "deg": 301.003
        },
        "rain": {},
        "snow": {},
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-12 12:00:00"
    }, {
        "dt": 1489330800,
        "main": {
            "temp": 278.557,
            "temp_min": 278.557,
            "temp_max": 278.557,
            "pressure": 931.73,
            "sea_level": 1029.72,
            "grnd_level": 931.73,
            "humidity": 73,
            "temp_kf": 0
        },
        "weather": [{
            "id": 803,
            "main": "Clouds",
            "description": "broken clouds",
            "icon": "04d"
        }],
        "clouds": {
            "all": 76
        },
        "wind": {
            "speed": 1.67,
            "deg": 311.503
        },
        "rain": {},
        "snow": {},
        "sys": {
            "pod": "d"
        },
        "dt_txt": "2017-03-12 15:00:00"
    }, {
        "dt": 1489341600,
        "main": {
            "temp": 274.57,
            "temp_min": 274.57,
            "temp_max": 274.57,
            "pressure": 932.43,
            "sea_level": 1031.09,
            "grnd_level": 932.43,
            "humidity": 86,
            "temp_kf": 0
        },
        "weather": [{
            "id": 500,
            "main": "Rain",
            "description": "light rain",
            "icon": "10n"
        }],
        "clouds": {
            "all": 32
        },
        "wind": {
            "speed": 0.84,
            "deg": 317.003
        },
        "rain": {
            "3h": 0.020000000000001
        },
        "snow": {},
        "sys": {
            "pod": "n"
        },
        "dt_txt": "2017-03-12 18:00:00"
    }],
    "city": {
        "id": 727011,
        "name": "Sofia",
        "coord": {
            "lat": 42.6975,
            "lon": 23.3242
        },
        "country": "BG"
    }
}`);