--������� SQL-������ ��� ��������� ��������� ��������: ������������ 
--�������, ������������ �������, ������������ �������, ��� ����� � ������������.
SELECT RegionName AS [������������ �������], SectorName AS [������������ �������], BuildingObjectName AS [������������ �������], EnterYear AS [��� ����� � ������������]
FROM dbo.[BuildingObject] INNER JOIN dbo.[Regions] ON Regions.RegionId = BuildingObject.RegionId
INNER JOIN dbo.[Sectors] ON Sectors.SectorId = BuildingObject.SectorId