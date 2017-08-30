# Prize Draw

Sample application for calculating the total prize monies given out as a result of a sales campaign.

This is a sample implementation of the requirements.  It has neither been performance profiled nor optimised for memory/CPU usage.

Currently an order is represented by its amount as a primitive int type and the daily orders by a list of amounts.
As the requirements grow, this can be refactored; 'orderlineitem' and 'ordergroup' entities can be created.

Cross cutting concerns should also be addressed, e.g.: caching, logging, validation and exception handling.