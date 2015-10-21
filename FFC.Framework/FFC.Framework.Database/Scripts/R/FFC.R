# Taking sample data
data1<-"http://rci.rutgers.edu/~rwomack/UNRATE.csv"
data2<-"http://rci.rutgers.edu/~rwomack/CPIAUCSL.csv"

#load sample data
data<-read.csv(data1, row.names=1)
#data$VALUE

#Monthly Transactions
tsDataMonthly <- ts(data$VALUE, start=c(1948,1), frequency = 12)
#tsDataMonthly
plot(tsDataMonthly)


#Weekly Transactions
tsDataWeekly <- ts(data$VALUE, start=c(1948,1), frequency = 365)
plot(tsDataWeekly)
?ts

library("ggplot2")
library("forecast")
?msts



#library("ggplot2")
#qplot(week, orders, data = tsDataWeekly, colour = as.factor(year), geom = "line")

y <- msts(tsDataWeekly, seasonal.periods=c(365.25))
#fit <- ets(y)
fit <- tbats(y)
fc <- forecast(fit,f=10)
#fc
head(fc)
plot(fc)

?msts
?tbats

#####################################################################
require(fpp)
num <- c(1,2,3,4,5,6)

#general
f1 <- meanf(num, h=1)
f2 <- rwf(num ,  h=1)
#Moving time average need to be done 

#Algos
fit1<- ets(num)
fit2 <- HoltWinters(num)

fcast1 <- forecast(fit1, h = 2)
fcast2 <- forecast(fit2, h = 2)

fcast1
fcast2
?forecast
f3
#summary(f1)
#?meanf



#######################################Custom X Axis
x1<- c(2,4,6,8,10,12)
plot(x1, xaxt = "n", xlab='Some Letters')
axis(1, at = 1:6, c("year1", "year2", "year3", "year4", "year5","year6"))
                    
                    
plot(1:10, xaxt = "n", xlab='Some Letters')
axis(1, at=1:10, c("year1", "year1", "year2", "year1", "year1","year1","year1","year1","year1","year1"))

############################################################# TSAxis
x<- c(1,2,3,4,5,6,7,8,9,10,11)
require(lubridate)
y = ts(x, start=c(2011, yday("2011-11-01")), frequency=365)
plot(forecast(ets(y), 10), xaxt="n")
a = seq(as.Date("2011-11-01"), by="weeks", length=11)
axis(1, at = decimal_date(a), labels = format(a, "%Y %b %d"), cex.axis=0.6)
abline(v = decimal_date(a), col='grey', lwd=0.5)



