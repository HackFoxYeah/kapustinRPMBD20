SELECT RegionName AS [������������ �������], COUNT(*) AS [���������� ������������ ��������]
FROM Regions INNER JOIN BuildingObject ON Regions.RegionId = BuildingObject.RegionId
GROUP BY RegionName