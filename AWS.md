Route53 Routing Policies
We have two (or more) regions running in active-active. Great! But how can Route53 distribute the load between these regions? Enter, Route53 Routing Policies. AWS offers many different policies:
* Simple routing policy: Point a domain to a single, simple resource.
* Failover routing policy: Designed for active-passive failover. Uses a simple policy unless it’s unhealthy, where it’ll use the backup.
* Geolocation routing policy: Route traffic based on the country or continent of your users.
* Geoproximity routing policy: Route traffic based on the physical distance between the region and your users.
* Latency routing policy: Route traffic to the AWS region that provides the best latency.
* Multivalue answer routing policy: Respond to DNS queries with up to eight healthy records selected at random.
* Weighted routing policy: Route traffic to resources in proportions that you specify.
