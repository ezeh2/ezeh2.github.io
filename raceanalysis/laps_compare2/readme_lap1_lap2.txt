
http://raceanalyse.test2.toasternet-online.de/phpmyadmin

SELECT count(*),line_id FROM `raceanalysis-2016-05-21`.`line_coordinate` group by line_id;

select count(*) from `raceanalysis-2016-05-21`.`line_coordinate`  where line_id=27;

select * from `raceanalysis-2016-05-21`.`line_coordinate`  where line_id=27 and idxTrace=1152;
/*
1106465
1108341
1110106
*/

-- lap1
select * from coordinates where idxTrace=1152 and id>=1106465 and id<=1108341;
-- lap2
select * from coordinates where idxTrace=1152 and id>=1108341 and id<=1110106;



/*

from database raceanalysis-2016-05-21 on windows-machine vs2010

in tables "lines"
line_id=27 -->	Cartagena Circuito de Velocidad, Spain

in tables "traces"
idxTrace=1152 --> 1152	idxUser=3	0	2016-02-26 10:14:01

in tables "users"
idxUser=3 --> 3	ME&C_A

1st two laps of user "3	ME&C_A" in "Cartagena Circuito de Velocidad, Spain" on 2016-02-26
select * from `raceanalysis-2016-05-21`.`line_coordinate`  where line_id=27 and idxTrace=1152;
/*
1106465 start of lap1
1108341 stop of lap1, start of lap2
1110106 start of lap2

lap1:
select * from coordinates where idxTrace=1152 and id>=1106465 and id<=1108341;
lap2:
select * from coordinates where idxTrace=1152 and id>=1108341 and id<=1110106;

*/