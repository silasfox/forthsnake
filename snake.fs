: not ( b -- b ) true xor ;
: myrand ( a b -- r ) over - utime + swap mod + ;

s" geometry.fs" included
s" graphics.fs" included
s" logic.fs"    included
s" setup.fs"    included

go
