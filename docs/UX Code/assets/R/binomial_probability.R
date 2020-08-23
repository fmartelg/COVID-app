positivity.rate <- 0.0231 # Positivity rate of 2.31%
number.attendees <- 10

# Probability at least one guest has COVID19
prob.zero.infected <- pbinom(0,
                             number.attendees,
                             positivity.rate)
prob.at.least.one.infected <- 1 - prob.zero.infected

# Return the probability
prob.at.least.one.infected
                                               