# Tanks game for Istok

## ������:

### ������� ���������: ������

>     ����������� ����� ����� (������, �������� � �.�.), ������� ��������� ��������:
>
> >     �������
> >     �������
> >     ������

### � ������:

> > >     ����������� ������ ��� �������, ��������� ����
> > >     ��������
> > >     ��������
> > >     ����������� ������������ ��������� �������� ������ (�� ���-�� �������)
> > >     ������� �������� ����� ��������� Main. � ���� ������ ����������:
> > >     ������� ��� ������� ������ ���� (�����, ������� � �.�., ��� ������������ � ����������) � �������� � �� ����������� ����������� ���������
> > >     ������� � ������� ���������� ����� ����� ������, ���������� ����� ����� ���������� � ��������� ��������

### ��� ����� ������� ������ � ������� ������ ����������� ��������������� ��������:

>     ������� � ����� ��������� ������ ���������� � ���� ���������. �������� � ���� ���-�� ������ ������ ���������� �����, ��������� �������� ������, � ��������� ���������� ����� (��� ������� ����� �������������� �������).
>     ������� � ���������� N ���-�� ������ �������.

### ����� ������ ��������� ��� ����������: ��������� ������� �� ������ ���� ��������� ����� ��������, ���� ��������.

>     �������� �������� �� ������������ ����� �������� �������������.

### ������� ���������: �������

>     �������� � ������ ������ �������� ����-�� �������� � ���������������� ��� � ������������, � ����� ����� ������� ��������.
>     �� ������� ������ ���������� ���-�� �������� ������ � ����������.
>     ����� ������� �������� ��������� N �������� �������.
>     ��� ������������ ������ �������� ��������� ��������, � ���� �� �������? ���� ����, ��������� �� ���-�� �� �������, ��� � ������� ��������� � ������������� ������� �������� ��� ������ ��� ��������� ����� ������� �������� ��� ����������, ����� ���� ��������� ���.
>     ������ �������� �������� �������, ��� ������� ������� ���-�� ������ �� ����� ���� ������ ���-�� ������, ����������� � ����������� ��� ������������� �������.
>     �� ����� ���� ���������� �������� �������, ��� ���� � ��� ������� ������������ ���-�� ������, �� ��������� ����� ��������.
>     �������� ����������� ������������ �������� � ������� (����������� ������� � ������������ 10%, ������ - 20%). ����������� ������� ����������� ���������� ������ �� 20%. ��������� � ������ �������� ������������ (��� ����������� ���� ��������, ��� �������, ����� ������������ �������� ��������).

### ������� ���������: �������

>     ����������� ���������� ��� ������ ������� � ����������. ��������� ��� ������� ������ ��������� ���������� ���� ������� � ������� �������, � ����� ������������� ����� ��������. ��������� ��� ���������� ������ ��������� ���������� ������ ���� ����������.
>     ������� ��������� ����� �������, ����������� ���������� ��� ������� � ����������, � ������� � ��� ���� �������� ��� �������, ����������� � ����������� (������� ����������).

# ������� 
> � �������� ������������� ������� �� �������� ���� ����������� ������� � �������� ������������ ������� ������� �����, � ������ ���������� � �������� ```Items``` ����� ���� ������� �� ���������� � ```Main``` ������� � �����������;
>> ��������� �������� ```tank``` � ```robot``` ������������ � ����������� ����� ������� � ��������� ����� ����.
>> � ���� ���� 3 �������� ������ - ```Shooting```, ```Mending```, ```ByBulle```, � ��� ���������� ������ ��� ��� �������� ���������� ������� ����� 2, ������� ��������������:
>> ```true``` - ��� ��������;
>> ```false``` - ��� ����������;
>> � �������� ����������, � ����������� �� ������ ������������ ����������� �������, � ������� �������� �����, ����������� ���������������� �������;
>> �� ����� ���� ���������� ������������ �� �� �������, ��� � ��� �������� �� ����� ����������� ��������� �������� ������� ```Random```; 
>> � �������� �������� ������������� ```try{} catch{}```, ���������� ���� ���������� - ```System.FormatException``` ��� ����� ������������ � ����������; 