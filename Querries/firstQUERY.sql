SELECT RegionName AS [Наименование региона], COUNT(*) AS [Количество строительных объектов]
FROM Regions INNER JOIN BuildingObject ON Regions.RegionId = BuildingObject.RegionId
GROUP BY RegionName