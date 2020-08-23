---
Author: Fernando Martel García
Date: 2020-07-27 16:16:09
---

# MyCOVID Risk app

## Objective

MyCOVID Risk app helps users assess the risk of COVID exposure at social gatherings. Specifically, it calculates the probability that at least one attendee will have COVID19 using two inputs: The local positivity rate, and the number of guests attending.  Users can use this info to inform decisions about attendance, and counter measures like masks, social distancing, and avoiding indoor spaces.  

MyCOVID Risk app **is not** designed to calculate the risk of contracting COVID at the gathering.  That would require *inter alia* much more information (e.g. extent of social distancing, how many attendees are already immune, how many are contagious, etc...).

## Usage Model

### Get exposure probability with user provided US state and attendees

- *As a* user *I want* an estimate of the risk of COVID19 exposure at a social gathering *so that* I can decide whether to attend, and if so, what counter measures to take (e.g. wear mask, social distancing, stay outside, etc.).
  - Positivity rates can come from third party [API](https://dataconomy.com/2020/04/apis-to-track-coronavirus-covid-19/)
  - The risk is computed using a binomial distribution (e.g. see this [calculator](https://stattrek.com/online-calculator/binomial.aspx)).
  - All probabilities are expressed in percentages to one decimal place for ease of use.

#### Acceptance criteria

- *Given* a user is in the app, and has internet access,
- *When* she enters the US `state` of District of Columbia, and the `expected number of attendees` of 10,
- *Then* the system:
  - Fetches the positivity rate for DC (e.g. 2.31 percent)
  - Calculates the `percent risk of at least 1 positive` attendee being COVID19 positive of 20.8 percent; and
  - the risk of zero attendees being COVID19 positive (or 100 - `percent risk of at least 1 positive` = 100 - 20.8 = 79.2),
  - in less than 1 second.

#### Prototype Screenshots

![ui_input](/assets/input.png)
![ui_output](/assets/output.png)

### Feature Backlog

- Monetization via ads
- Expand geo coverage beyond USA
- Use coarse phone location to select default state

## High level architecture

![architecture](/assets/architecture.svg)

## Tech stack

- Front end: Bootstrap
  - Theme: [Material Kit](https://www.creative-tim.com/product/material-kit)
- Data: [Rolling Positivity rate avg](https://github.com/owid/covid-19-data/blob/master/public/data/owid-covid-codebook.csv)

We want to build and app quickly and cheaply. This means using "no code" platforms. The market for such platforms divides in two:

- Business app platforms: Built by businesses for employees.
- Consumer app platforms: Built for consumers.

The former have excellent back end integration (e.g. with server side data, functions, APIs) but no monetization. The latter have nice UX, and monetization but no back end integration.

There is also an options of building native apps, hybrid apps, and progressive web apps (PWA).  The latter work on the browser but behave like an app (link in home screen, work offline).

Below is my quick overview o leading platforms:

| Vendor     | API    | AdMob     | Geolocation | Publish | Price/M USD  |
| ---------- | ------ | --------- | ----------- | ------- | ------------ |
| Appery.io  | Y      | Write JS? | Y           | Y       | 25           |
| Shoutem    | Custom | Y         | Maybe       | Y       | 179          |
| AppyPie    | N      | Y         | Y           | Y       | 60/app/month |
| GoodBarber | ?      | Y         | ?            | ?      |              |

- Appery is the only consumer app platform with native support for server side functions, and third party APIs via [API Express](https://appery.io/api-express/).  However, it is not as intuitive as the other platforms, and lacks native AdMob support.
- Shoutem is simple, nice UX, but calling server functions requires [custom development](https://shoutem.github.io/docs/extensions/tutorials/getting-started). Accessing external database requires premium subscription.
- AppyPie is the simplest but also the most limited. No API support.
- GoodBarber focuses on progressive web apps (PWA).  That might be the most flexible route but then you have to rely on SEO for adoption (they don't go via Google or Apple app markets, as far as I understand it).

## Prototype

I have created a free trial with Appery. Credentials:

- User name: fmg313@gmail.com
- Password: RuFdTQ"p=|i1+PG7@tit

There you will find two apps: One built with JQ framework, and one with Ionic 4, in case we want to [hack AdMob](https://www.youtube.com/watch?v=_tAL5LwZEeo) later.  What remains to be done are:

1. Linking UX inputs, and buttons to [events and actions](https://docs.appery.io/docs/appbuilder-jqm-events-and-actions).  How this is done depends on the backend database / logic.
2. Back end APIs and functions.
