Vector2 is struct.

When creating a field with this data type, you must specify coords x and y

For example:

Vector2 _vector = new vector2(1, 4);
or
Vector2 _vector = new vector2(1.5f, 4.37f);


if you need to refer to the coordinate of the vector, then just do it!

For example:

Console.Writeline(_vector.x);
or
Console.Writeline(_vector.y);

			~~~simple operation~~~
You can perform simple mathematical operations just like 
with any other data types like int, float, double;

For example:

Vector2 _vector = new vector2(1, 4);
_vector = _vector + _vector;
Console.Writeline(_vector.y); //returns 8
Console.Writeline(_vector.x); //returns 2

_vector = _vector - _vector;
Console.Writeline(_vector.y); //return 0
Console.Writeline(_vector.x); //return 0

_vector = _vector * _vector;
Console.Writeline(_vector.y); //returns 1
Console.Writeline(_vector.x); //returns 16

_vector = _vector / _vector;
Console.Writeline(_vector.y); //returns 1
Console.Writeline(_vector.x); //returns 1

And you can performs operation with numbers

For examle:

_vector = _vector * 3;
Console.Writeline(_vector.y); //returns 3
Console.Writeline(_vector.x); //returns 12

_vector = _vector / 2;
Console.Writeline(_vector.y); //returns 0.5f
Console.Writeline(_vector.x); //returns 2


			~~~simple operation~~~
зerforming complex operations on vectors will return exactly
what you would be able to calculate yourself

it is worth considering that even though you create a vector 
pointing to a point, for example (1, 5), vectors are defined by two 
points, that is, ANY vector you create has a starting point at coordinate (0, 0) 
and points to the point you set, as in the example (1, 5).

For example:

Vector2.Corner(_samleVector1, _samleVector2) returns corner between this vectors

Vector2.Normal(_sameVector) returns a vector perpendicular to the specified vector

Vector2.Lenght(_sameVector) returns scalar value (float)

Vector2.ScalarMult(_samleVector1, _samleVector2) returns the sum of the multiplications 
of the corresponding coordinates

Vector2.Normalize(_sameVector) returns the unit vector

Vector2.MidNormal(_sameVector) same as the Normal, 
but it points to a point if the coordinates start was not 
at the point (0, 0), but from the center of the specified vector

Vector2.MidNormalShort(_sameVector) same as the MidNormal, but lenght of
normal is unit