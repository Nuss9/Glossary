# Buckaroo kickstart

[Buckaroo](https://www.buckaroo.nl/) is a Payment Service Provider (PSP) from Dutch origin which is on the market for quite some time already. The code in this project functions as a kickstart to get you up and running faster.

Buckaroo Servcies required for the sample code are the '[Subscription](https://support.buckaroo.nl/categorieen/subscriptions?mark=Subscriptions)' and '[Credit Management](https://support.buckaroo.nl/categorieen/credit-management?mark=credit%20management)' parts. The .NET SDK has not been used.

The template contains the HTTP Client to be injected in your DI container, which will be sending requests using [HMAC](https://wiki.wearetriple.com/pages/viewpage.action?spaceKey=GEN&title=Office+VPN). Also included is an example request to [GET a debtor](https://dev.buckaroo.nl/AdditionalServices/Description/creditmanagement#debtorinfo) (a.k.a. customer). 

Documentation can be found here:
- [Plaza](https://plaza.buckaroo.nl/)
   _Portal from which to access your created data by GUI_
- [Dev Documentation](https://dev.buckaroo.nl/)
   _Code examples, sandbox_
- [Support](https://support.buckaroo.nl/)
   _Functional support pages, FAQ_
